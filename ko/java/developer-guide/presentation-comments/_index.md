---
title: Java에서 프레젠테이션 주석 관리
linktitle: 프레젠테이션 주석
type: docs
weight: 100
url: /ko/java/presentation-comments/
keywords:
- 주석
- 현대 주석
- PowerPoint 주석
- 프레젠테이션 주석
- 슬라이드 주석
- 주석 추가
- 주석 접근
- 주석 편집
- 주석 답글
- 주석 제거
- 주석 삭제
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 프레젠테이션 주석을 관리합니다: PowerPoint 프레젠테이션에서 주석을 빠르고 쉽게 추가, 읽기, 편집, 답글 달기 및 제거합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Java를 사용하여 프레젠테이션 주석을 관리하는 방법을 설명합니다. 주요 주석 관련 유형을 소개하고 슬라이드에 주석을 추가하고, 기존 주석에 접근하고, 답글 및 최신 주석을 작업하며, 프레젠테이션에서 주석을 제거하는 방법을 시연합니다.

예제에서는 PowerPoint의 일반적인 검토 및 협업 시나리오를 다루며, 저자에게 주석을 할당하고, 주석 텍스트와 메타데이터를 읽고, 답글 체인을 구축하고, 선택된 주석 또는 모든 주석을 제거하는 방법을 보여줍니다.

PowerPoint에서 주석은 슬라이드에 표시되는 주석으로 나타납니다. 주석을 선택하면 해당 텍스트와 관련 토론이 표시됩니다.

프레젠테이션을 열 때 주석 자체를 변경하지 않고 주석을 표시하거나 숨기려면, [Show or Hide Comments When Opening a Presentation](/slides/ko/java/presentation-view-properties/)를 참조하십시오.

## **프레젠테이션에 주석을 추가하는 이유는?**

프레젠테이션을 검토할 때 주석을 사용하여 피드백을 제공하고 동료와 협업할 수 있습니다.

Aspose.Slides for Java는 주석 작업을 위한 다음 API를 제공합니다:

* [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스는 프레젠테이션의 주석 저자에 대한 접근을 제공합니다.
* [ICommentCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icommentcollection/) 인터페이스는 개별 저자와 연결된 주석을 나타냅니다.
* [IComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icomment/) 인터페이스는 주석에 대한 정보를 제공하며, 여기에는 저자, 생성 시간, 위치 및 텍스트가 포함됩니다.
* [CommentAuthor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/commentauthor/) 클래스는 저자에 대한 정보를 제공하고, 이름, 이니셜 및 연결된 주석을 포함합니다.

## **슬라이드 주석 추가**

다음 예제는 PowerPoint 프레젠테이션의 슬라이드에 주석을 추가하는 방법을 보여줍니다:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    Point2D.Float position = new Point2D.Float(0.2f, 0.2f);
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

## **슬라이드 주석 접근**

다음 예제는 PowerPoint 프레젠테이션에서 기존 주석에 접근하는 방법을 보여줍니다:

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

## **주석에 답글 달기**

부모 주석은 답글 계층 구조의 최상위에 있는 원래 주석입니다. [IComment.getParentComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icomment/#getParentComment--) 및 [IComment.setParentComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) 메서드를 사용하면 주석의 부모를 가져오거나 설정할 수 있습니다.

다음 예제는 답글을 추가하고 결과적인 주석 계층 구조를 검사하는 방법을 보여줍니다:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Point2D.Float position = new Point2D.Float(10, 10);
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

{{% alert color="warning" title="Warning" %}}
* 주석을 삭제하기 위해 [IComment.remove](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icomment/#remove--) 메서드를 사용하면 해당 주석에 대한 모든 답글도 삭제됩니다.
* [IComment.setParentComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) 이 순환 참조를 만들 경우, [PptxEditException](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pptxeditexception/)이 발생합니다.
{{% /alert %}}

## **현대 주석 추가**

현대 주석은 슬라이드 자체, 특정 도형, 또는 AutoShape 내부의 텍스트 범위와 연결될 수 있습니다. [ICommentCollection.addModernComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) 메서드는 슬라이드와 주석 표시기 좌표 외에 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/) 매개변수를 허용합니다.

`null`을 shape 매개변수로 전달하면 주석은 슬라이드 수준 주석이 됩니다. 표시기는 제공된 좌표에 따라 배치되지만 특정 도형과 연결되지 않으므로 [IModernComment.getShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getShape--)은 `null`을 반환합니다. [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/)을 제공하면 주석은 해당 도형에 고정됩니다. 좌표는 여전히 슬라이드에서 주석 표시기의 위치를 정의하며, 도형 연관성은 [IModernComment.getShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getShape--)을 통해 가져올 수 있습니다.

### **모던 주석을 도형에 고정**

다음 예제는 슬라이드 수준의 현대 주석과 특정 AutoShape에 고정된 현대 주석을 모두 생성합니다. 그런 다음 각 주석에서 연결된 도형을 읽어옵니다.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    Point2D.Float slideCommentPosition = new Point2D.Float(20, 20);
    Point2D.Float shapeCommentPosition = new Point2D.Float(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **다양한 도형 유형에 주석 고정**

[IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/)를 구현하는 모든 슬라이드 객체는 도형 고정점으로 사용할 수 있습니다. 일반적인 예제로는 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iconnector/), 차트와 같은 [IGraphicalObject](https://reference.aspose.com/slides/ko/java/com.aspose.slides/igraphicalobject/) 인스턴스가 있습니다.

다음 예제는 여러 일반 도형 유형을 생성하고 각각에 현대 주석을 연결합니다.

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
import java.awt.geom.Point2D;
import java.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    Point2D.Float autoShapeCommentPosition = new Point2D.Float(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    Point2D.Float pictureCommentPosition = new Point2D.Float(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    Point2D.Float groupCommentPosition = new Point2D.Float(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    Point2D.Float connectorCommentPosition = new Point2D.Float(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    Point2D.Float chartCommentPosition = new Point2D.Float(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **텍스트에 주석 고정 및 상태 설정**

[IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)와 연결된 현대 주석의 경우, [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--) 및 [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int--)는 도형 텍스트 프레임에서 선택된 텍스트의 시작 위치에 접근합니다. [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) 및 [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int--)는 선택 길이에 접근합니다. 이 값들을 함께 사용하면 주석을 AutoShape 내부의 특정 텍스트 범위와 연결합니다.

[IModernComment.getStatus](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getStatus--) 및 [IModernComment.setStatus](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#setStatus-byte--) 메서드는 [ModernCommentStatus](https://reference.aspose.com/slides/ko/java/com.aspose.slides/moderncommentstatus/) 상수값에 접근합니다:

- `NotDefined` — 특정 현대 주석 상태가 정의되지 않음.
- `Active` — 주석이 활성 상태임.
- `Resolved` — 주석이 해결됨.
- `Closed` — 주석이 종료됨.

다음 예제는 도형에 고정된 현대 주석을 만들고, 텍스트 선택과 연결한 뒤, 해결된 것으로 표시하고, 프레젠테이션을 저장한 후 파일을 다시 열어 값을 검증합니다.

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
import java.awt.geom.Point2D;
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
    Point2D.Float commentPosition = new Point2D.Float(60, 60);
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

### **기존 현대 주석 검사**

기존 프레젠테이션을 검사하려면, 어떤 주석이 [IModernComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/)을 구현하는지 확인한 다음, [IModernComment.getShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--), 및 [IModernComment.getStatus](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getStatus--)를 검사합니다. `null` 도형은 슬라이드 수준 주석을 의미합니다. [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/) 고정점의 경우, 텍스트 선택 메서드는 도형 텍스트 프레임 내의 관련 범위를 식별합니다.

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

## **주석 제거**

### **모든 주석 및 주석 작성자 제거**

다음 예제는 프레젠테이션에서 모든 주석 및 주석 작성자를 제거하는 방법을 보여줍니다:

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

### **특정 주석 제거**

다음 예제는 슬라이드에서 특정 주석을 제거하는 방법을 보여줍니다:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    Point2D.Float firstCommentPosition = new Point2D.Float(0.2f, 0.2f);
    Point2D.Float secondCommentPosition = new Point2D.Float(0.3f, 0.2f);
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

**Aspose.Slides가 현대 주석에 대한 해결 상태를 지원합니까?**

예. [IModernComment.getStatus](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getStatus--) 및 [IModernComment.setStatus](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#setStatus-byte--)는 `Resolved`를 포함한 [ModernCommentStatus](https://reference.aspose.com/slides/ko/java/com.aspose.slides/moderncommentstatus/) 값을 가져옵니다. 이 상태는 프레젠테이션에 저장되며 파일을 다시 열어도 다시 읽을 수 있습니다.

**스레드형 토론(답글 체인)이 지원되며, 중첩 제한이 있습니까?**

예. 각 주석은 [parent comment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icomment/#getParentComment--)을 참조할 수 있어 답글 체인을 가능하게 합니다. API에서는 특정 중첩 깊이 제한을 정의하지 않습니다.

**슬라이드에서 주석 표시기의 위치는 어떤 좌표계로 정의됩니까?**

표시기 위치는 슬라이드 좌표계의 부동 소수점 좌표로 정의되며, 슬라이드 상에 정확히 배치할 수 있습니다.