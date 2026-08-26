---
title: Управление комментариями презентаций в Node.js
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
- доступ к комментариям
- редактировать комментарий
- отвечать на комментарий
- удалить комментарий
- удалить комментарий
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте комментариями к презентациям с помощью Aspose.Slides for Node.js via Java: добавляйте, читайте, редактируйте, отвечайте и удаляйте комментарии в презентациях PowerPoint."
---
## **Обзор**

В этой статье объясняется, как управлять комментариями презентации с помощью Aspose.Slides for Node.js via Java. Описываются основные типы, связанные с комментариями, и демонстрируется, как добавлять комментарии на слайды, получать доступ к существующим комментариям, работать с ответами и современными комментариями, а также удалять комментарии из презентации.

Примеры охватывают типичные сценарии рецензирования и совместной работы в PowerPoint, такие как назначение комментариев авторам, чтение текста комментариев и метаданных, построение цепочек ответов и удаление выбранных комментариев или всех комментариев.

В PowerPoint комментарии отображаются как аннотации на слайдах. Выбор комментария показывает его текст и связанную дискуссию.

## **Зачем добавлять комментарии к презентациям?**

Вы можете использовать комментарии для предоставления обратной связи и совместной работы с коллегами при просмотре презентаций.

* Класс [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) предоставляет доступ к авторам комментариев презентации.
* Класс [CommentCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/commentcollection/) представляет комментарии, связанные с отдельным автором.
* Класс [Comment](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/comment/) предоставляет информацию о комментарии, включая его автора, время создания, позицию и текст.
* Класс [CommentAuthor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/commentauthor/) предоставляет информацию об авторе, включая его имя, инициалы и связанные комментарии.

## **Добавить комментарии к слайдам**

Следующий пример показывает, как добавить комментарии к слайдам в презентации PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    const author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const createdTime = java.newInstanceSync("java.util.Date");

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    const comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        const firstComment = comments[0];
        console.log(firstComment.getText());

        const authorComments = firstComment.getAuthor().getComments();
        const commentText = authorComments.get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Получить комментарии со слайдов**

Следующий пример показывает, как получить доступ к существующим комментариям в презентации PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("Comments1.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const author = authors.get_Item(authorIndex);
        const comments = author.getComments();

        for (let commentIndex = 0; commentIndex < comments.size(); commentIndex++) {
            const comment = comments.get_Item(commentIndex);
            console.log("Slide: " + comment.getSlide().getSlideNumber());
            console.log("Comment: " + comment.getText());
            console.log("Author: " + comment.getAuthor().getName());
            console.log("Posted at: " + comment.getCreatedTime());
            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ответить на комментарии**

Родительский комментарий — это исходный комментарий в вершине иерархии ответов. Методы [Comment.getParentComment](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/comment/getparentcomment/) и [Comment.setParentComment](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/comment/setparentcomment/) позволяют получить или установить родительский комментарий.

Следующий пример показывает, как добавить ответы и исследовать получившуюся иерархию комментариев:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    const author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    const reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    const subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    const comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    const reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    const comments = slide.getSlideComments(null);
    for (let index = 0; index < comments.length; index++) {
        let comment = comments[index];
        let indentation = "";
        while (comment.getParentComment() != null) {
            indentation += "\t";
            comment = comment.getParentComment();
        }

        console.log(indentation + comments[index].getAuthor().getName() + ": " + comments[index].getText());
    }

    presentation.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* При использовании метода [Comment.remove](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/comment/remove/) для удаления комментария все ответы на этот комментарий также удаляются.
* Если метод [Comment.setParentComment](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/comment/setparentcomment/) создает кольцевую ссылку, будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Добавить современные комментарии**

Современные комментарии могут быть связаны со слайдом, с конкретной фигурой или с диапазоном текста внутри [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/). Метод [CommentCollection.addModernComment](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) принимает аргумент [Shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/) в дополнение к координатам слайда и маркера комментария.

Когда в аргумент shape передаётся `null`, комментарий является комментариев уровня слайда. Его маркер позиционируется по указанным координатам, но не связан с конкретной фигурой, поэтому [ModernComment.getShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/moderncomment/getshape/) возвращает `null`. Когда передаётся [Shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/), комментарий привязывается к этой фигуре. Координаты всё равно определяют позицию маркера комментария на слайде, а связь с фигурой можно получить через [ModernComment.getShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Привязать современный комментарий к фигуре**

Следующий пример создает как современный комментарий уровня слайда, так и современный комментарий, привязанный к конкретному [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/). Затем он считывает связанную фигуру из каждого комментария.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    const createdTime = java.newInstanceSync("java.util.Date");
    const slideCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));
    const shapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    const shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    console.log(slideComment.getShape() == null);
    console.log(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Привязать комментарии к разным типам фигур**

Любой объект слайда, производный от [Shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/), может использоваться в качестве привязки к фигуре. Общие примеры включают [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/connector/) и экземпляры [GraphicalObject](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/graphicalobject/), такие как диаграммы.

Следующий пример создаёт несколько распространённых типов фигур и связывает с каждой из них современный комментарий.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const createdTime = java.newInstanceSync("java.util.Date");

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    const autoShapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(30), java.newFloat(30));
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    const imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    const imageData = java.newArray("byte", Array.from(Buffer.from(imageBase64, "base64")));
    const image = presentation.getImages().addImage(imageData);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 120, 80, image);
    const pictureCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(230), java.newFloat(30));
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    const groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 100, 0, 80, 40);
    const groupCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(40), java.newFloat(150));
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 220, 150, 140, 40);
    const connectorCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(240), java.newFloat(150));
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 400, 20, 250, 180);
    const chartCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(420), java.newFloat(40));
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Привязать комментарий к тексту и установить его статус**

Для современного комментария, связанного с [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/), методы [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) и [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) получают начальную позицию выбранного текста в текстовом фрейме фигуры. Методы [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) и [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) получают длину выделения. Вместе эти значения связывают комментарий с конкретным диапазоном текста внутри [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/).

Методы [ModernComment.getStatus](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/moderncomment/getstatus/) и [ModernComment.setStatus](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/moderncomment/setstatus/) получают значение из перечисления [ModernCommentStatus](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — не определён конкретный статус современного комментария.
- `Active` — комментарий активен.
- `Resolved` — комментарий разрешён.
- `Closed` — комментарий закрыт.

Следующий пример создаёт современный комментарий, привязанный к фигуре, связывает его с выделением текста, отмечает как разрешённый, сохраняет презентацию и проверяет значения после повторного открытия файла.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const outputFile = "modern_comment_text_anchor.pptx";
const shapeText = "Review the quarterly revenue forecast.";
const selectedText = "quarterly revenue";
const expectedSelectionStart = shapeText.indexOf(selectedText);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const commentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const createdTime = java.newInstanceSync("java.util.Date");
    const comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, createdTime);
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length);
    comment.setStatus(aspose.slides.ModernCommentStatus.Resolved);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedComments = reopenedSlide.getSlideComments(null);

    for (let index = 0; index < reopenedComments.length; index++) {
        const reopenedComment = reopenedComments[index];
        if (!java.instanceOf(reopenedComment, "com.aspose.slides.IModernComment")) {
            continue;
        }

        const shapeMatches = reopenedComment.getShape() != null && reopenedComment.getShape().getName() === "Forecast text";
        const selectionStartMatches = reopenedComment.getTextSelectionStart() === expectedSelectionStart;
        const selectionLengthMatches = reopenedComment.getTextSelectionLength() === selectedText.length;
        const statusMatches = reopenedComment.getStatus() === aspose.slides.ModernCommentStatus.Resolved;

        console.log("Shape anchor preserved: " + shapeMatches);
        console.log("Text selection start preserved: " + selectionStartMatches);
        console.log("Text selection length preserved: " + selectionLengthMatches);
        console.log("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Проверить существующие современные комментарии**

Чтобы проверить существующую презентацию, определите, какие комментарии являются экземплярами [ModernComment](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/moderncomment/), затем изучите [ModernComment.getShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) и [ModernComment.getStatus](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/moderncomment/getstatus/). Фигура `null` указывает на комментарий уровня слайда. Для привязки к [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) методы выбора текста определяют соответствующий диапазон в текстовом фрейме фигуры.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("comments.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const comments = slide.getSlideComments(null);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (!java.instanceOf(comment, "com.aspose.slides.IModernComment")) {
                continue;
            }

            console.log("Slide: " + slide.getSlideNumber());
            console.log("Text: " + comment.getText());
            console.log("Status: " + comment.getStatus());

            const shape = comment.getShape();
            if (shape == null) {
                console.log("Anchor: slide level");
            } else {
                console.log("Anchor shape: " + shape.getName());
                console.log("Anchor type: " + shape.getClass().getSimpleName());

                if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                    console.log("Text selection start: " + comment.getTextSelectionStart());
                    console.log("Text selection length: " + comment.getTextSelectionLength());
                }
            }

            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Удалить комментарии**

### **Удалить все комментарии и их авторов**

Следующий пример показывает, как удалить все комментарии и их авторов из презентации:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let index = 0; index < authors.size(); index++) {
        authors.get_Item(index).getComments().clear();
    }

    authors.clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Удалить отдельные комментарии**

Следующий пример показывает, как удалить отдельные комментарии со слайда:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Author", "A");
    const createdTime = java.newInstanceSync("java.util.Date");

    const firstCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const secondCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.3), java.newFloat(0.2));
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const commentAuthor = authors.get_Item(authorIndex);
        const commentsToRemove = [];
        const comments = slide.getSlideComments(commentAuthor);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (comment.getText() === "comment 1") {
                commentsToRemove.push(comment);
            }
        }

        for (const comment of commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Поддерживает ли Aspose.Slides статус «разрешён» для современных комментариев?**

Да. Методы [ModernComment.getStatus](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/moderncomment/getstatus/) и [ModernComment.setStatus](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/moderncomment/setstatus/) получают значение [ModernCommentStatus](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/moderncommentstatus/), включая `Resolved`. Статус сохраняется в презентации и может быть снова считан после повторного открытия файла.

**Поддерживаются ли цепочки обсуждений (ветвленные ответы) и есть ли ограничение вложенности?**

Да. Каждый комментарий может ссылаться на свой [parent comment](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/comment/getparentcomment/), что позволяет создавать цепочки ответов. API не задаёт конкретного ограничения глубины вложенности.

**В какой системе координат определено положение маркера комментария на слайде?**

Позиция маркера задаётся координатами с плавающей точкой в системе координат слайда, что позволяет точно разместить его на слайде.