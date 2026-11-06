---
title: Управление комментариями презентации в Node.js
linktitle: Комментарии к презентации
type: docs
weight: 100
url: /ru/nodejs-java/presentation-comments/
keywords:
- комментарий
- современный комментарий
- комментарии PowerPoint
- комментарии к презентации
- комментарии слайдов
- добавить комментарий
- получить комментарий
- редактировать комментарий
- ответить на комментарий
- удалить комментарий
- удалить комментарий
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управление комментариями презентаций с помощью Aspose.Slides for Node.js via Java: добавление, чтение, редактирование, ответы и удаление комментариев в презентациях PowerPoint."
---
## **Обзор**

Эта статья объясняет, как управлять комментариями презентации с помощью Aspose.Slides for Node.js via Java. Она вводит основные типы, связанные с комментариями, и демонстрирует, как добавлять комментарии к слайдам, получать доступ к существующим комментариям, работать с ответами и современными комментариями, а также удалять комментарии из презентации.

Примеры охватывают типичные сценарии рецензирования и совместной работы в PowerPoint, такие как назначение комментариев авторам, чтение текста комментария и метаданных, построение цепочек ответов и удаление выбранных комментариев или всех комментариев.

В PowerPoint комментарии отображаются как аннотации на слайдах. Выбор комментария отображает его текст и связанную дискуссию.

Чтобы запросить отображение или скрытие комментариев при открытии презентации без изменения самих комментариев, см. [Показать или скрыть комментарии при открытии презентации](/slides/ru/nodejs-java/presentation-view-properties/).

## **Зачем добавлять комментарии в презентации?**

Вы можете использовать комментарии для предоставления обратной связи и совместной работы с коллегами при рецензировании презентаций.

Aspose.Slides for Node.js via Java предоставляет следующие API для работы с комментариями:

* Класс [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) предоставляет доступ к авторам комментариев презентации.
* Класс [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/) представляет комментарии, связанные с конкретным автором.
* Класс [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/) предоставляет информацию о комментарии, включая автора, время создания, позицию и текст.
* Класс [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/) предоставляет информацию об авторе, включая его имя, инициалы и связанные комментарии.

## **Добавление комментариев к слайдам**

Пример создаёт два слайда и регистрирует автора комментария с помощью [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/). Он использует [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) для размещения одного комментария на каждом слайде, затем получает комментарии первого слайда для этого автора с помощью [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/). Консоль выводит текст первого комментария дважды, демонстрируя доступ как через слайд, так и через автора, а сохранённая презентация содержит оба комментария.

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

        const commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Поиск или создание автора комментария**

Когда автоматический обзор неоднократно обрабатывает одну и ту же презентацию, ищите в коллекции, возвращаемой [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/), перед добавлением автора. Метод [findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/) сопоставляет как имя, так и инициалы и возвращает массив подходящих авторов или пустой массив, если совпадений нет. В отличие от него, [findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/) ищет только по имени, независимо от инициалов. Вызов [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) с именем и инициалами, уже присутствующими в коллекции, вызывает исключение.

Пример требует файл презентации как минимум с одним слайдом. На каждом из двух проходов он переиспользует первого найденного автора или создаёт нового только при пустом результате. Если найдено несколько совпадений, выбирается первый элемент массива без объединения или удаления остальных авторов. Затем вызывается [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) для выбранного автора и сохраняет презентацию. Во втором проходе открывается результат первого прохода и операция повторяется.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const authorName = "Reviewer";
const authorInitials = "RV";

let inputFile = "input.pptx";
const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));

for (let pass = 1; pass <= 2; pass++) {
    const presentation = new aspose.slides.Presentation(inputFile);
    try {
        const matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        const author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        const createdTime = java.newInstanceSync("java.util.Date");
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, createdTime);

        const outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

Во втором проходе добавляется ещё один комментарий без создания дополнительного автора или удаления существующих комментариев. Финальный файл `review_pass_2.pptx` содержит оба новых комментария наряду с любыми оригинальными. Переиспользование автора не устраняет дублирование комментариев: чтобы избежать многократного добавления одного и того же комментария, реализуйте отдельную проверку дубликатов перед добавлением.

## **Получение комментариев слайда**

Пример открывает существующую презентацию и читает коллекцию, возвращаемую [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/). Для каждого автора он перебирает коллекцию, возвращаемую [getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/), и выводит номер слайда, текст комментария, имя автора и время создания. Исходная презентация должна содержать комментарии, чтобы получить вывод в консоль.

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

## **Ответы на комментарии**

Родительским комментарием считается исходный комментарий в верхушке иерархии ответов. Методы [Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) и [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) позволяют получить или установить родителя комментария.

Пример создаёт комментарии от двух авторов и использует [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) для построения ответов, включая ответ на другой ответ. Передача `null` в [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) получает комментарии от всех авторов; консоль отступает каждый элемент в соответствии с его глубиной в иерархии ответов. Пример сохраняет полное обсуждение, вызывает [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) для первого корневого комментария и сохраняет вторую презентацию без этого комментария и его ответов.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    const reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    const secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    const subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    const separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    const separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

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

    rootComment.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* При использовании метода [Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) для удаления комментария также удаляются все ответы на этот комментарий.
* Если [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) создаёт циклическую ссылку, выбрасывается [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Добавление современных комментариев**

Современные комментарии могут быть связаны непосредственно со слайдом, с конкретной фигурой или с диапазоном текста внутри AutoShape. Метод [CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) принимает аргумент [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) в дополнение к слайду и координатам маркера комментария.

Когда в качестве аргумента shape передаётся `null`, комментарий является комментариев уровня слайда. Его маркер позиционируется по заданным координатам, но не привязан к конкретной фигуре, поэтому [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) возвращает `null`. При передаче [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) комментарий привязывается к этой фигуре. Координаты по‑прежнему определяют позицию маркера на слайде, а связь с фигурой можно получить через [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/).

### **Привязка современного комментария к фигуре**

Пример дважды вызывает [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/): один раз с `null` shape для комментария уровня слайда и один раз с прямоугольником в качестве привязки. Чтение [getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) выводит `true` для проверки `null` у комментария уровня слайда и `Revenue title` для привязанного комментария. Оба комментария сохраняются в презентацию.

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

### **Привязка комментариев к различным типам фигур**

Любой объект слайда, наследующий от [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/), может использоваться в качестве привязки. Распространённые примеры включают [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/) и [GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/) такие как диаграммы.

Пример использует [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) для привязки комментария к каждому из пяти типов фигур: AutoShape, picture frame, группа, коннектор и диаграмма. Картинка использует встроенные данные изображения, поэтому внешнее изображение не требуется. Каждый комментарий имеет своё положение маркера, и сохранённая презентация сохраняет все пять привязок к фигурам.

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

### **Привязка комментария к тексту и установка его статуса**

Для современного комментария, связанного с [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), методы [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) и [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) получают начальную позицию выбранного текста в текстовом фрейме фигуры. Методы [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) и [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) получают длину выбора. Вместе эти значения связывают комментарий с конкретным диапазоном текста внутри AutoShape.

Методы [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) и [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) работают со значением из перечисления [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — статус современного комментария не определён.
- `Active` — комментарий активен.
- `Resolved` — комментарий разрешён.
- `Closed` — комментарий закрыт.

Пример привязывает современный комментарий к словам «quarterly revenue» в тексте прямоугольника. Он вычисляет нулевой старт выбора из текста и передаёт его в [setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/), а затем использует [setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) для установки количества выбранных символов. После вызова [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) с `Resolved` презентация сохраняется и открывается вновь. Четыре проверки в консоли должны вывести `true`, подтверждая сохранение привязки к фигуре, диапазону текста и статуса.

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
    comment.setStatus(java.newByte(aspose.slides.ModernCommentStatus.Resolved));

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

### **Исследование существующих современных комментариев**

Пример требует существующую презентацию, содержащую современные комментарии, и выводит их текст, статус и детали привязки. Чтобы проанализировать их, проверьте, являются ли комментарии экземплярами [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/), затем изучите [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) и [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/). `null` shape указывает на комментарий уровня слайда. Для привязки к [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) методы выбора текста определяют соответствующий диапазон в текстовом фрейме фигуры.

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

## **Удаление комментариев**

Aspose.Slides for Node.js via Java позволяет удалить все комментарии и их авторов из презентации или удалить выбранные комментарии, оставив остальные. Ниже приведены примеры, демонстрирующие оба подхода и сохраняющие обновлённую презентацию.

### **Удаление всех комментариев и их авторов**

Пример открывает существующую презентацию и вызывает [CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/) для каждого автора, затем вызывает [CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/) для удаления самих авторов. Сохранённая презентация не содержит ни комментариев, ни их авторов. Используйте презентацию с комментариями, чтобы увидеть результат удаления.

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

### **Удаление конкретных комментариев**

Пример создаёт два комментария на одном слайде и использует [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) для поиска комментариев каждого автора. Он собирает комментарии, текст которых равен «comment 1», перед вызовом [CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/), избегая изменения коллекции во время выбора. Сохранённая презентация оставляет только «comment 2».

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

**Поддерживает ли Aspose.Slides статус «Resolved» для современных комментариев?**

Да. Методы [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) и [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) работают со значением [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/), включая `Resolved`. Статус сохраняется в презентации и может быть считан после повторного открытия файла.

**Поддерживаются ли цепочки ответов (нити обсуждений) и есть ли ограничение вложенности?**

Да. Каждый комментарий может ссылаться на свой [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/), что позволяет формировать цепочки ответов. API не задаёт конкретного ограничения глубины вложенности.

**В какой системе координат определяется позиция маркера комментария на слайде?**

Позиция маркера задаётся координатами с плавающей точкой в системе координат слайда, что позволяет точно разместить его на слайде.