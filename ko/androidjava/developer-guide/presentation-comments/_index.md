---
title: Android에서 프레젠테이션 댓글 관리
linktitle: 프레젠테이션 댓글
type: docs
weight: 100
url: /ko/androidjava/presentation-comments/
keywords:
- 댓글
- 현대 댓글
- PowerPoint 댓글
- 프레젠테이션 댓글
- 슬라이드 댓글
- 댓글 추가
- 댓글 접근
- 댓글 편집
- 댓글 회신
- 댓글 제거
- 댓글 삭제
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 프레젠테이션 댓글을 관리합니다: PowerPoint 프레젠테이션에서 댓글을 빠르고 쉽게 추가, 읽기, 편집, 회신 및 삭제할 수 있습니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Android via Java를 사용하여 프레젠테이션 댓글을 관리하는 방법을 설명합니다. 주요 댓글 관련 유형을 소개하고 슬라이드에 댓글을 추가하고 기존 댓글에 접근하며, 회신 및 최신 댓글을 처리하고, 프레젠테이션에서 댓글을 제거하는 방법을 보여줍니다.

예제에서는 PowerPoint의 일반적인 검토 및 협업 시나리오를 다루며, 댓글을 작성자에게 할당하고, 댓글 텍스트와 메타데이터를 읽으며, 회신 체인을 구축하고, 선택된 댓글 또는 모든 댓글을 제거하는 방법을 보여줍니다.

PowerPoint에서 댓글은 슬라이드에 주석 형태로 표시됩니다. 댓글을 선택하면 해당 텍스트와 관련 토론이 표시됩니다.

## **프레젠테이션에 댓글을 추가하는 이유는?**

프레젠테이션을 검토할 때 피드백을 제공하고 동료와 협업하기 위해 댓글을 사용할 수 있습니다.

Aspose.Slides for Android via Java는 댓글 작업을 위한 다음 API를 제공합니다:

* The [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스는 프레젠테이션의 댓글 작성자에 대한 접근을 제공합니다.
* The [ICommentCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icommentcollection/) 인터페이스는 개별 작성자와 연관된 댓글을 나타냅니다.
* The [IComment](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icomment/) 인터페이스는 댓글에 대한 정보를 제공하며, 작성자, 생성 시간, 위치 및 텍스트를 포함합니다.
* The [CommentAuthor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/commentauthor/) 클래스는 작성자에 대한 정보를 제공하며, 이름, 이니셜 및 연관된 댓글을 포함합니다.

## **슬라이드 댓글 추가**

다음 예제는 PowerPoint 프레젠테이션의 슬라이드에 댓글을 추가하는 방법을 보여줍니다:

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

## **댓글에 회신하기**

부모 댓글은 회신 계층 구조의 최상위에 있는 원본 댓글입니다. [IComment.getParentComment](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icomment/#getParentComment--) 및 [IComment.setParentComment](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) 메서드를 사용하여 댓글의 부모를 가져오거나 설정할 수 있습니다.

다음 예제는 회신을 추가하고 결과 댓글 계층 구조를 검사하는 방법을 보여줍니다:

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

{{% alert color="warning" title="Warning" %}}
* [IComment.remove](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icomment/#remove--) 메서드를 사용하여 댓글을 삭제하면 해당 댓글에 대한 모든 회신도 삭제됩니다.
* [IComment.setParentComment](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) 메서드가 순환 참조를 생성하면 [PptxEditException](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pptxeditexception/)이 발생합니다.
{{% /alert %}}

## **최신 댓글 추가**

최신 댓글은 슬라이드 자체, 특정 도형, 또는 AutoShape 내부의 텍스트 범위와 연결될 수 있습니다. [ICommentCollection.addModernComment](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) 메서드는 슬라이드와 댓글 마커 좌표 외에 [IShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/) 인수를 받습니다.

`null`이 도형 인수로 전달되면 댓글은 슬라이드 수준 댓글이 됩니다. 마커는 제공된 좌표에 따라 배치되지만 특정 도형과 연결되지 않으며, 따라서 [IModernComment.getShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imoderncomment/#getShape--) 은 `null`을 반환합니다. [IShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/)가 제공되면 댓글이 해당 도형에 고정됩니다. 좌표는 여전히 슬라이드상의 댓글 마커 위치를 정의하며, 도형 연결은 [IModernComment.getShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imoderncomment/#getShape--) 을 통해 확인할 수 있습니다.

### **현대 댓글을 도형에 고정**

다음 예제는 슬라이드 수준 최신 댓글과 특정 AutoShape에 고정된 최신 댓글을 모두 생성합니다. 그런 다음 각 댓글에서 연관된 도형을 읽어옵니다.

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

### **다양한 도형 유형에 댓글 고정**

[IShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/)를 구현하는 모든 슬라이드 객체는 도형 앵커로 사용할 수 있습니다. 일반적인 예로는 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iconnector/) 및 차트와 같은 [IGraphicalObject](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/igraphicalobject/) 인스턴스가 있습니다.

다음 예제는 여러 일반적인 도형 유형을 생성하고 각 도형에 최신 댓글을 연결합니다.

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

### **텍스트에 댓글을 고정하고 상태 설정**

[IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/)와 연결된 최신 댓글의 경우, [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) 및 [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int--) 은 도형의 텍스트 프레임에서 선택된 텍스트의 시작 위치에 접근합니다. [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) 및 [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int--) 은 선택 영역의 길이에 접근합니다. 이 값들을 함께 사용하면 댓글을 AutoShape 내부의 특정 텍스트 범위와 연결할 수 있습니다.

[IModernComment.getStatus](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imoderncomment/#getStatus--) 및 [IModernComment.setStatus](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte--) 메서드는 [ModernCommentStatus](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/moderncommentstatus/) 상수 중 하나의 값을 가져오거나 설정합니다:

- `NotDefined` — 특별히 정의된 최신 댓글 상태가 없습니다.
- `Active` — 댓글이 활성 상태입니다.
- `Resolved` — 댓글이 해결되었습니다.
- `Closed` — 댓글이 닫혔습니다.

다음 예제는 도형에 고정된 최신 댓글을 만들고, 텍스트 선택과 연결한 뒤, 해결된 상태로 표시하고, 프레젠테이션을 저장한 다음 파일을 다시 열어 값들을 확인합니다.

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

### **기존 최신 댓글 검사**

기존 프레젠테이션을 검사하려면, 어떤 댓글이 [IModernComment](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imoderncomment/)를 구현하는지 확인한 뒤, [IModernComment.getShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--), [IModernComment.getStatus](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imoderncomment/#getStatus--) 를 조사합니다. `null` 도형은 슬라이드 수준 댓글을 의미합니다. [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 앵커의 경우, 텍스트 선택 메서드가 도형 텍스트 프레임 내 연관된 범위를 식별합니다.

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

다음 예제는 프레젠테이션에서 모든 댓글 및 댓글 작성자를 제거하는 방법을 보여줍니다:

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

**Aspose.Slides는 최신 댓글에 대한 해결 상태를 지원하나요?**

예. [IModernComment.getStatus](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imoderncomment/#getStatus--) 및 [IModernComment.setStatus](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte--)를 통해 `Resolved`를 포함한 [ModernCommentStatus](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/moderncommentstatus/) 값을 가져오거나 설정할 수 있습니다. 이 상태는 프레젠테이션에 저장되며 파일을 다시 연 후에도 읽을 수 있습니다.

**스레드 형식 토론(회신 체인)이 지원되며, 중첩 깊이 제한이 있나요?**

예. 각 댓글은 [parent comment](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icomment/#getParentComment--)를 참조할 수 있어 회신 체인을 만들 수 있습니다. API에서 특정 중첩 깊이 제한은 정의되지 않았습니다.

**슬라이드에서 댓글 마커 위치는 어떤 좌표계로 정의되나요?**

마커 위치는 슬라이드 좌표계의 부동소수점 좌표로 정의되며, 이를 통해 슬라이드에 정확히 배치할 수 있습니다.