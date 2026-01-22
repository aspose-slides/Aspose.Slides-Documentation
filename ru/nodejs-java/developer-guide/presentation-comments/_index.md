---
title: Управление комментариями презентаций на JavaScript
linktitle: Комментарии к презентации
type: docs
weight: 100
url: /ru/nodejs-java/presentation-comments/
keywords:
- комментарий
- современный комментарий
- комментарии PowerPoint
- комментарии к презентации
- комментарии к слайдам
- добавить комментарий
- доступ к комментарию
- редактировать комментарий
- ответить на комментарий
- удалить комментарий
- удалить комментарий
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Освойте работу с комментариями презентаций с Aspose.Slides для Node.js: быстро и легко добавляйте, читайте, редактируйте и удаляйте комментарии в файлах PowerPoint с помощью JavaScript."
---

В PowerPoint комментарий отображается как заметка или аннотация на слайде. При щелчке по комментарию его содержимое или сообщения отображаются. 

## **Зачем добавлять комментарии в презентации?**

Вы можете использовать комментарии, чтобы дать обратную связь или общаться с коллегами при проверке презентаций.

Чтобы вы могли использовать комментарии в презентациях PowerPoint, Aspose.Slides for Node.js via Java предоставляет

* Класс [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), который содержит коллекцию авторов (из класса [CommentAuthorCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthorCollection)). Авторы добавляют комментарии к слайдам.
* Класс [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection), который содержит коллекцию комментариев для отдельных авторов.
* Класс [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment), который содержит информацию об авторах и их комментариях: кто добавил комментарий, время его добавления, позицию комментария и т.д.
* Класс [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentAuthor), который содержит информацию об отдельных авторах: имя автора, его инициалы, комментарии, связанные с именем автора, и т.д.

## **Добавить комментарий к слайду**
Этот JavaScript‑код показывает, как добавить комментарий к слайду в презентации PowerPoint:
```javascript
// Создает экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Добавляет пустой слайд
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // Добавляет автора
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // Устанавливает позицию для комментариев
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // Добавляет комментарий к слайду для автора на слайде 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // Добавляет комментарий к слайду для автора на слайде 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // Получает ISlide 1
    var slide = pres.getSlides().get_Item(0);
    // Когда в качестве аргумента передаётся null, комментарии всех авторов загружаются на выбранный слайд
    var Comments = slide.getSlideComments(author);
    // Получает комментарий с индексом 0 для слайда 1
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // Выбирает коллекцию комментариев автора с индексом 0
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Получить доступ к комментариям слайда**
Этот JavaScript‑код показывает, как получить доступ к существующему комментарию на слайде в презентации PowerPoint:
```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ответы на комментарии**
Родительский комментарий — это верхний или оригинальный комментарий в иерархии комментариев или ответов. С помощью методов [getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#getParentComment--) или [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) (из класса [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment)) можно задать или получить родительский комментарий.

Этот JavaScript‑код показывает, как добавить комментарии и получить ответы на них:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Adds a comment
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // Adds a reply to comment1
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // Adds another reply to comment1
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // Add a reply to an existing reply
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // Displays the comments hierarchy on console
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // Removes comment1 and all replies to it
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" title="Attention" %}} 

* При использовании метода [Remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#remove--) (из класса [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment)) для удаления комментария ответы на комментарий также удаляются.
* Если настройка [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) приводит к циклической ссылке, будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException).

{{% /alert %}}

## **Добавить современный комментарий**

В 2021 году Microsoft представила современные комментарии в PowerPoint. Функция современных комментариев существенно улучшает совместную работу в PowerPoint. С помощью современных комментариев пользователи PowerPoint могут отмечать комментарии как решённые, привязывать их к объектам и текстам, а также взаимодействовать гораздо проще, чем раньше. 

Aspose.Slides поддерживает современные комментарии классом [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ModernComment). Методы [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) и [insertModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) были добавлены в класс [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommentCollection).

Этот JavaScript‑код показывает, как добавить современный комментарий к слайду в презентации PowerPoint:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Удалить комментарий**

### **Удалить все комментарии и авторов**

Этот JavaScript‑код показывает, как удалить все комментарии и авторов в презентации:
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Удаляет все комментарии из презентации
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // Удаляет всех авторов
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


### **Удалить конкретные комментарии**

Этот JavaScript‑код показывает, как удалить конкретные комментарии на слайде:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // добавить комментарии...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // удалить все комментарии, содержащие текст "comment 1"
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Часто задаваемые вопросы**

**Поддерживает ли Aspose.Slides статус, например «решённый», для современных комментариев?**

Да. Современные комментарии предоставляют методы [getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) и [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setStatus/); вы можете читать и задавать состояние комментария (например, пометить его как решённый), и это состояние сохраняется в файле и распознаётся PowerPoint.

**Поддерживаются ли обсуждения в виде цепочек ответов и есть ли ограничение вложенности?**

Да. Каждый комментарий может ссылаться на свой родительский комментарий, что позволяет создавать произвольные цепочки ответов. API не задаёт конкретного ограничения глубины вложенности.

**В какой системе координат определена позиция маркера комментария на слайде?**

Позиция хранится как точка с плавающей запятой в системе координат слайда. Это позволяет точно разместить маркер комментария в нужном месте.