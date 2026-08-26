---
title: Java에서 프레젠테이션 댓글 관리
linktitle: 프레젠테이션 댓글
type: docs
weight: 100
url: /ko/java/presentation-comments/
keywords:
- 댓글
- 최신 댓글
- PowerPoint 댓글
- 프레젠테이션 댓글
- 슬라이드 댓글
- 댓글 추가
- 댓글 접근
- 댓글 편집
- 댓글 답글
- 댓글 제거
- 댓글 삭제
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 프레젠테이션 댓글을 관리합니다: PowerPoint 프레젠테이션에서 댓글을 빠르고 쉽게 추가, 읽기, 편집, 답글 달기 및 제거합니다."
---
## **개요**

이 문서는 Aspose.Slides for Java를 사용하여 프레젠테이션 댓글을 관리하는 방법을 설명합니다. 주요 댓글 관련 유형을 소개하고 슬라이드에 댓글을 추가하고, 기존 댓글에 접근하며, 답글 및 최신 댓글을 처리하고, 프레젠테이션에서 댓글을 제거하는 방법을 보여줍니다.

예제는 PowerPoint에서 일반적인 검토 및 협업 시나리오를 다루며, 작성자별 댓글 할당, 댓글 텍스트 및 메타데이터 읽기, 답글 체인 구축, 선택된 댓글 또는 모든 댓글 삭제 등을 포함합니다.

PowerPoint에서 댓글은 슬라이드에 표시되는 주석 형태로 나타납니다. 댓글을 선택하면 해당 텍스트와 관련 논의가 표시됩니다.

## **왜 프레젠테이션에 댓글을 추가해야 할까요?**

프레젠테이션을 검토할 때 피드백을 제공하고 동료와 협업하기 위해 댓글을 사용할 수 있습니다.

Aspose.Slides for Java는 댓글 작업을 위한 다음 API를 제공합니다:

* [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스 – 프레젠테이션의 댓글 작성자에 접근합니다.
* [ICommentCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icommentcollection/) 인터페이스 – 개별 작성자와 연결된 댓글을 나타냅니다.
* [IComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icomment/) 인터페이스 – 작성자, 생성 시각, 위치, 텍스트 등을 포함한 댓글 정보를 제공합니다.
* [CommentAuthor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/commentauthor/) 클래스 – 이름, 이니셜 및 연결된 댓글을 포함한 작성자 정보를 제공합니다.

## **슬라이드 댓글 추가**

다음 예제는 PowerPoint 프레젠테이션에 슬라이드 댓글을 추가하는 방법을 보여줍니다:

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

## **슬라이드 댓글 접근**

다음 예제는 PowerPoint 프레젠테이션에서 기존 댓글에 접근하는 방법을 보여줍니다:

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

## **댓글에 답글 달기**

상위 댓글은 답글 계층 구조의 최상위에 있는 원본 댓글입니다. [IComment.getParentComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icomment/#getParentComment--) 및 [IComment.setParentComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) 메서드를 사용하면 댓글의 상위 댓글을 가져오거나 설정할 수 있습니다.

다음 예제는 답글을 추가하고 결과 댓글 계층 구조를 검사하는 방법을 보여줍니다:

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

{{% alert color="warning" title="경고" %}}
* [IComment.remove](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icomment/#remove--) 메서드로 댓글을 삭제하면 해당 댓글에 대한 모든 답글도 함께 삭제됩니다.
* [IComment.setParentComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) 메서드가 순환 참조를 만들 경우 [PptxEditException](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pptxeditexception/)이 발생합니다.
{{% /alert %}}

## **최신 댓글 추가**

최신 댓글은 슬라이드 자체, 특정 도형, 또는 AutoShape 내부의 텍스트 범위와 연결될 수 있습니다. [ICommentCollection.addModernComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) 메서드는 슬라이드 및 댓글 마커 좌표 외에 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/) 인수를 추가로 받습니다.

`null`을 도형 인수로 전달하면 해당 댓글은 슬라이드 수준 댓글이 됩니다. 마커는 제공된 좌표에 따라 배치되지만 특정 도형과 연결되지 않으므로 [IModernComment.getShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getShape--)은 `null`을 반환합니다. [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/)을 제공하면 댓글이 해당 도형에 고정됩니다. 좌표는 여전히 슬라이드상의 마커 위치를 정의하고, 도형 연결은 [IModernComment.getShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getShape--)을 통해 확인할 수 있습니다.

### **현대 댓글을 도형에 고정하기**

다음 예제는 슬라이드 수준 최신 댓글과 특정 AutoShape에 고정된 최신 댓글을 모두 생성하고, 각 댓글에서 연결된 도형을 읽어옵니다.

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

### **다양한 도형 유형에 댓글 고정하기**

[IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/)을 구현하는 모든 슬라이드 객체를 도형 고정점으로 사용할 수 있습니다. 일반적인 예로는 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iconnector/), 그리고 차트와 같은 [IGraphicalObject](https://reference.aspose.com/slides/ko/java/com.aspose.slides/igraphicalobject/) 인스턴스가 포함됩니다.

다음 예제는 여러 일반 도형 유형을 생성하고 각각에 최신 댓글을 연결합니다.

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

### **텍스트에 댓글 고정하고 상태 설정하기**

[IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)에 연결된 최신 댓글의 경우, [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--) 및 [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int--) 메서드로 도형 텍스트 프레임에서 선택된 텍스트의 시작 위치에 접근합니다. [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) 및 [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int--) 메서드로 선택 영역의 길이를 접근합니다. 이 값들을 함께 사용하면 댓글을 AutoShape 내부의 특정 텍스트 범위와 연결할 수 있습니다.

[IModernComment.getStatus](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getStatus--) 및 [IModernComment.setStatus](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#setStatus-byte--) 메서드는 [ModernCommentStatus](https://reference.aspose.com/slides/ko/java/com.aspose.slides/moderncommentstatus/) 상수 중 하나인 값을 접근합니다:

- `NotDefined` — 특정 최신 댓글 상태가 정의되지 않음.
- `Active` — 댓글이 활성 상태임.
- `Resolved` — 댓글이 해결됨.
- `Closed` — 댓글이 닫힘.

다음 예제는 도형에 고정된 최신 댓글을 생성하고, 텍스트 선택에 연결하며, 해결된 상태로 표시하고, 프레젠테이션을 저장한 뒤 파일을 다시 연 후 값을 검증합니다.

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

### **기존 최신 댓글 검사하기**

기존 프레젠테이션을 검사하려면 먼저 어떤 댓글이 [IModernComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/)를 구현하는지 확인하고, 그 후 [IModernComment.getShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--), 그리고 [IModernComment.getStatus](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getStatus--)를 조사합니다. `null` 도형은 슬라이드 수준 댓글을 나타냅니다. [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)에 고정된 경우 텍스트 선택 메서드가 도형 텍스트 프레임 내의 해당 범위를 식별합니다.

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

## **댓글 제거**

### **모든 댓글 및 댓글 작성자 제거**

다음 예제는 프레젠테이션에서 모든 댓글과 댓글 작성자를 제거하는 방법을 보여줍니다:

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

### **특정 댓글 제거**

다음 예제는 슬라이드에서 특정 댓글을 제거하는 방법을 보여줍니다:

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

**Aspose.Slides가 최신 댓글에 대한 해결 상태를 지원하나요?**

예. [IModernComment.getStatus](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#getStatus--) 및 [IModernComment.setStatus](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imoderncomment/#setStatus-byte-) 메서드를 통해 [ModernCommentStatus](https://reference.aspose.com/slides/ko/java/com.aspose.slides/moderncommentstatus/) 값 중 `Resolved`를 포함한 상태에 접근할 수 있습니다. 상태는 프레젠테이션에 저장되며 파일을 다시 연 후에도 읽을 수 있습니다.

**스레드형 토론(답글 체인)이 지원되며 중첩 제한은 있나요?**

예. 각 댓글은 [parent comment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icomment/#getParentComment--)를 참조할 수 있어 답글 체인을 만들 수 있습니다. API에서 특정 중첩 깊이 제한을 정의하고 있지 않습니다.

**댓글 마커 위치는 슬라이드의 어떤 좌표계로 정의되나요?**

마커 위치는 슬라이드 좌표계의 부동 소수점 좌표로 정의되어 슬라이드 상의 정확한 위치에 배치할 수 있습니다.