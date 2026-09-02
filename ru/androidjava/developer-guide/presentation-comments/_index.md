---
title: Управление комментариями презентаций на Android
linktitle: Комментарии к презентациям
type: docs
weight: 100
url: /ru/androidjava/presentation-comments/
keywords:
- комментарий
- современный комментарий
- комментарии PowerPoint
- комментарии к презентации
- комментарии слайдов
- добавить комментарий
- доступ к комментариям
- редактировать комментарий
- ответить на комментарий
- удалить комментарий
- удалить комментарий
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте комментариями презентаций с помощью Aspose.Slides for Android via Java: добавляйте, читайте, редактируйте, отвечайте и удаляйте комментарии в презентациях PowerPoint быстро и легко."
---
## **Обзор**

В этой статье описывается, как управлять комментариями презентации с помощью Aspose.Slides for Android via Java. Представлены основные типы, связанные с комментариями, и демонстрируется, как добавлять комментарии на слайды, получать доступ к существующим комментариям, работать с ответами и современными комментариями, а также как удалять комментарии из презентации.

Примеры охватывают типичные сценарии рецензирования и совместной работы в PowerPoint, такие как назначение комментариев авторам, чтение текста комментария и метаданных, построение цепочек ответов и удаление выбранных комментариев или всех комментариев.

В PowerPoint комментарии отображаются как аннотации на слайдах. Выбор комментария показывает его текст и связанную дискуссию.

## **Зачем добавлять комментарии в презентации?**

Вы можете использовать комментарии для предоставления обратной связи и совместной работы с коллегами при рецензировании презентаций.

Aspose.Slides for Android via Java предоставляет следующие API для работы с комментариями:

* Класс [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/), который предоставляет доступ к авторам комментариев презентации.
* Интерфейс [ICommentCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icommentcollection/), представляющий комментарии, связанные с отдельным автором.
* Интерфейс [IComment](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icomment/), который предоставляет информацию о комментарии, включая автора, время создания, позицию и текст.
* Класс [CommentAuthor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/commentauthor/), который предоставляет информацию об авторе, включая имя, инициалы и связанные комментарии.

## **Добавление комментариев к слайдам**

Следующий пример показывает, как добавить комментарии к слайдам в презентации PowerPoint:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    PointF position = new PointF(0.2f, 0.2f);
    Date createdTime = new Date();

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    IComment[] comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        IComment firstComment = comments[0];
        System.out.println(firstComment.getText());

        ICommentCollection authorComments = firstComment.getAuthor().getComments();
        String commentText = authorComments.get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Доступ к комментариям слайдов**

Следующий пример показывает, как получить доступ к существующим комментариям в презентации PowerPoint:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        for (IComment comment : author.getComments()) {
            System.out.println("Slide: " + comment.getSlide().getSlideNumber());
            System.out.println("Comment: " + comment.getText());
            System.out.println("Author: " + comment.getAuthor().getName());
            System.out.println("Posted at: " + comment.getCreatedTime());
            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ответы на комментарии**

Родительским комментарием считается оригинальный комментарий вверху иерархии ответов. Методы [IComment.getParentComment](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icomment/#getParentComment--) и [IComment.setParentComment](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) позволяют получить или задать родительский комментарий.

Следующий пример показывает, как добавить ответы и проанализировать получившуюся иерархию комментариев:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    PointF position = new PointF(10, 10);
    Date createdTime = new Date();

    ICommentAuthor author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    IComment comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++) {
        IComment comment = comments[i];
        while (comment.getParentComment() != null) {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() + ": " + comments[i].getText());
    }

    presentation.save("parent_comment.pptx", SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Предупреждение" %}}
* При использовании метода [IComment.remove](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icomment/#remove--) для удаления комментария также удаляются все ответы на этот комментарий.
* Если [IComment.setParentComment](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) создаёт круговую ссылку, будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Добавление современных комментариев**

Современные комментарии могут быть связаны непосредственно со слайдом, с определённой фигурой или с диапазоном текста внутри AutoShape. Метод [ICommentCollection.addModernComment](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) принимает аргумент [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/) в дополнение к слайду и координатам маркера комментария.

Когда в качестве аргумента shape передаётся `null`, комментарий является слайд-уровневым. Его маркер позиционируется по переданным координатам, но не привязан к какой‑либо фигуре, поэтому [IModernComment.getShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imoderncomment/#getShape--) возвращает `null`. При передаче [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/) комментарий привязывается к этой фигуре. Координаты по‑прежнему определяют положение маркера комментария на слайде, а связь с фигурой можно получить через [IModernComment.getShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imoderncomment/#getShape--).

### **Привязка современного комментария к фигуре**

Следующий пример создаёт как слайд‑уровневый современный комментарий, так и современный комментарий, привязанный к конкретному AutoShape. Затем он считывает связанную фигуру из каждого комментария.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    PointF slideCommentPosition = new PointF(20, 20);
    PointF shapeCommentPosition = new PointF(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Привязка комментариев к различным типам фигур**

Любой объект слайда, реализующий [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/), может использоваться в качестве якоря фигуры. Распространённые примеры включают [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iconnector/) и экземпляры [IGraphicalObject](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/igraphicalobject/), такие как диаграммы.

Следующий пример создаёт несколько распространённых типов фигур и связывает с каждой из них современный комментарий.

```java
import com.aspose.slides.ChartType;
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IChart;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IConnector;
import com.aspose.slides.IGroupShape;
import com.aspose.slides.IPPImage;
import com.aspose.slides.IPictureFrame;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    PointF autoShapeCommentPosition = new PointF(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    PointF pictureCommentPosition = new PointF(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    PointF groupCommentPosition = new PointF(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    PointF connectorCommentPosition = new PointF(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    PointF chartCommentPosition = new PointF(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Привязка комментария к тексту и установка его статуса**

Для современного комментария, связанного с [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/), методы [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) и [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) получают начальную позицию выбранного текста во фрейме текста фигуры. Методы [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) и [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) получают длину выделения. Вместе эти значения связывают комментарий с конкретным диапазоном текста внутри AutoShape.

Методы [IModernComment.getStatus](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imoderncomment/#getStatus--) и [IModernComment.setStatus](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) получают значение из констант [ModernCommentStatus](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/moderncommentstatus/):

- `NotDefined` — конкретный статус современного комментария не определён.
- `Active` — комментарий активен.
- `Resolved` — комментарий решён.
- `Closed` — комментарий закрыт.

Следующий пример создаёт современный комментарий, привязанный к фигуре, связывает его с выделением текста, помечает как решённый, сохраняет презентацию и проверяет значения после повторного открытия файла.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.ModernCommentStatus;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Date;

String outputFile = "modern_comment_text_anchor.pptx";
String shapeText = "Review the quarterly revenue forecast.";
String selectedText = "quarterly revenue";
int expectedSelectionStart = shapeText.indexOf(selectedText);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    PointF commentPosition = new PointF(60, 60);
    IModernComment comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, new Date());
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length());
    comment.setStatus(ModernCommentStatus.Resolved);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IComment[] reopenedComments = reopenedSlide.getSlideComments(null);

    for (IComment reopenedComment : reopenedComments) {
        if (!(reopenedComment instanceof IModernComment)) {
            continue;
        }

        IModernComment modernComment = (IModernComment) reopenedComment;
        boolean shapeMatches = modernComment.getShape() != null && "Forecast text".equals(modernComment.getShape().getName());
        boolean selectionStartMatches = modernComment.getTextSelectionStart() == expectedSelectionStart;
        boolean selectionLengthMatches = modernComment.getTextSelectionLength() == selectedText.length();
        boolean statusMatches = modernComment.getStatus() == ModernCommentStatus.Resolved;

        System.out.println("Shape anchor preserved: " + shapeMatches);
        System.out.println("Text selection start preserved: " + selectionStartMatches);
        System.out.println("Text selection length preserved: " + selectionLengthMatches);
        System.out.println("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **Просмотр существующих современных комментариев**

Чтобы проанализировать существующую презентацию, проверьте, какие комментарии реализуют [IModernComment](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imoderncomment/), затем изучите [IModernComment.getShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--), и [IModernComment.getStatus](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imoderncomment/#getStatus--). Значение `null` у shape указывает на слайд‑уровневый комментарий. Для якоря [IAutoShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iautoshape/) методы выбора текста определяют соответствующий диапазон в текстовом фрейме фигуры.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.IModernComment;
import com.aspose.slides.IShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("comments.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        IComment[] comments = slide.getSlideComments(null);
        for (IComment comment : comments) {
            if (!(comment instanceof IModernComment)) {
                continue;
            }

            IModernComment modernComment = (IModernComment) comment;
            System.out.println("Slide: " + slide.getSlideNumber());
            System.out.println("Text: " + modernComment.getText());
            System.out.println("Status: " + modernComment.getStatus());

            IShape shape = modernComment.getShape();
            if (shape == null) {
                System.out.println("Anchor: slide level");
            } else {
                System.out.println("Anchor shape: " + shape.getName());
                System.out.println("Anchor type: " + shape.getClass().getSimpleName());

                if (shape instanceof IAutoShape) {
                    System.out.println("Text selection start: " + modernComment.getTextSelectionStart());
                    System.out.println("Text selection length: " + modernComment.getTextSelectionLength());
                }
            }

            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Удаление комментариев**

### **Удаление всех комментариев и их авторов**

Следующий пример показывает, как удалить все комментарии и их авторов из презентации:

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("example.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        author.getComments().clear();
    }

    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Удаление конкретных комментариев**

Следующий пример показывает, как удалить определённые комментарии со слайда:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    PointF firstCommentPosition = new PointF(0.2f, 0.2f);
    PointF secondCommentPosition = new PointF(0.3f, 0.2f);
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors()) {
        List<IComment> commentsToRemove = new ArrayList<IComment>();
        IComment[] comments = slide.getSlideComments(commentAuthor);

        for (IComment comment : comments) {
            if ("comment 1".equals(comment.getText())) {
                commentsToRemove.add(comment);
            }
        }

        for (IComment comment : commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Поддерживает ли Aspose.Slides статус «решён» для современных комментариев?**

Да. Методы [IModernComment.getStatus](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imoderncomment/#getStatus--) и [IModernComment.setStatus](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) позволяют получить/установить значение [ModernCommentStatus](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/moderncommentstatus/), включая `Resolved`. Статус сохраняется в презентации и может быть считан после повторного открытия файла.

**Поддерживаются ли ветвленные обсуждения (цепочки ответов) и существует ли ограничение глубины вложенности?**

Да. Каждый комментарий может ссылаться на свой [parent comment](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/icomment/#getParentComment--), что позволяет создавать цепочки ответов. API не определяет конкретного ограничения глубины вложения.

**В какой системе координат определяется позиция маркера комментария на слайде?**

Позиция маркера задаётся координатами с плавающей запятой в системе координат слайда, что позволяет точно разместить его на слайде.