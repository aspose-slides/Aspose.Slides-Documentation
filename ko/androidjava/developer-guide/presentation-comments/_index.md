---
title: Android에서 프레젠테이션 주석 관리
linktitle: 프레젠테이션 주석
type: docs
weight: 100
url: /ko/androidjava/presentation-comments/
keywords:
- 주석
- 최신 주석
- PowerPoint 주석
- 프레젠테이션 주석
- 슬라이드 주석
- 주석 추가
- 주석 액세스
- 주석 편집
- 주석 답글
- 주석 제거
- 주석 삭제
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 프레젠테이션 주석을 관리합니다: PowerPoint 프레젠테이션에서 주석을 빠르고 쉽게 추가, 읽기, 편집, 답글 달기 및 제거할 수 있습니다."
---
## **개요**

이 문서는 Java를 통해 Aspose.Slides for Android에서 프레젠테이션 주석을 관리하는 방법을 설명합니다. 주요 주석 관련 유형을 소개하고 슬라이드에 주석을 추가하고, 기존 주석에 접근하고, 답글 및 최신 주석을 사용하며, 프레젠테이션에서 주석을 제거하는 방법을 보여줍니다.

예제는 PowerPoint에서 일반적인 검토 및 협업 시나리오를 다루며, 작성자에게 주석을 할당하고, 주석 텍스트와 메타데이터를 읽고, 답글 체인을 구성하고, 선택된 주석 또는 모든 주석을 제거하는 방법을 설명합니다.

PowerPoint에서 주석은 슬라이드에 표시되는 주석 도구입니다. 주석을 선택하면 해당 텍스트와 관련 토론이 표시됩니다.

프레젠테이션을 열 때 주석 자체를 변경하지 않고 주석을 표시하거나 숨기려면 [프레젠테이션 열 때 주석 표시 또는 숨기기](/slides/ko/androidjava/presentation-view-properties/)를 참조하십시오.

## **왜 프레젠테이션에 주석을 추가합니까?**

프레젠테이션을 검토할 때 피드백을 제공하고 동료와 협업하기 위해 주석을 사용할 수 있습니다.

Aspose.Slides for Android via Java은 주석 작업을 위한 다음 API를 제공합니다.

* [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 클래스는 프레젠테이션의 주석 작성자에 대한 액세스를 제공합니다.
* [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/) 인터페이스는 개별 작성자와 연결된 주석을 나타냅니다.
* [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/) 인터페이스는 작성자, 생성 시간, 위치 및 텍스트를 포함한 주석 정보를 제공합니다.
* [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentauthor/) 클래스는 이름, 이니셜 및 연결된 주석을 포함한 작성자 정보를 제공합니다.

## **슬라이드 주석 추가**

예제는 두 개의 슬라이드를 만든 다음 [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-)을 사용하여 주석 작성자를 등록합니다. 각 슬라이드에 하나씩 주석을 배치하기 위해 [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-)을 사용하고, 해당 작성자에 대해 첫 번째 슬라이드의 주석을 [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-)으로 가져옵니다. 콘솔은 첫 번째 주석의 텍스트를 두 번 출력하여 슬라이드와 작성자를 통해 모두 접근할 수 있음을 보여주며, 저장된 프레젠테이션에는 두 주석이 모두 포함됩니다.

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

        String commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **주석 작성자 찾기 또는 만들기**

자동 검토가 동일한 프레젠테이션을 반복적으로 처리할 때, 작성자를 추가하기 전에 [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--)가 반환하는 컬렉션을 검색합니다. [findByNameAndInitials](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByNameAndInitials-java.lang.String-java.lang.String-)은 이름과 이니셜을 모두 일치시켜 일치하는 작성자 배열을 반환하며, 일치 항목이 없으면 빈 배열을 반환합니다. 반면에 [findByName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByName-java.lang.String-)은 이름만으로 검색하며 이니셜은 무시합니다. 컬렉션에 이미 존재하는 이름과 이니셜으로 [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-)를 호출하면 예외가 발생합니다.

예제는 최소 하나의 슬라이드가 포함된 프레젠테이션 파일이 필요합니다. 두 번의 반복 작업에서 첫 번째 일치하는 작성자를 재사용하거나 결과가 비어 있을 때만 새 작성자를 생성합니다. 일치 항목이 여러 개일 경우 다른 작성자를 병합하거나 제거하지 않고 첫 번째 배열 요소를 선택합니다. 그런 다음 선택된 작성자에 대해 [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-)을 호출하고 프레젠테이션을 저장합니다. 두 번째 반복은 첫 번째 반복의 출력을 열고 동일한 작업을 반복합니다.

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

final String authorName = "Reviewer";
final String authorInitials = "RV";

String inputFile = "input.pptx";
PointF position = new PointF(20, 20);

for (int pass = 1; pass <= 2; pass++) {
    Presentation presentation = new Presentation(inputFile);
    try {
        ICommentAuthor[] matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        ICommentAuthor author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, new Date());

        String outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

두 번째 반복은 다른 작성자를 추가하거나 기존 주석을 제거하지 않고 또 다른 주석을 추가합니다. 최종 파일 `review_pass_2.pptx`에는 새 주석 두 개와 원래 주석이 모두 포함됩니다. 작성자를 재사용해도 주석이 중복 제거되지 않으므로 같은 주석을 반복적으로 추가하지 않으려면 추가 전에 별도의 중복 감지를 구현해야 합니다.

## **슬라이드 주석 액세스**

예제는 기존 프레젠테이션을 열고 [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--)가 반환하는 컬렉션을 읽습니다. 각 작성자에 대해 [getComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthor/#getComments--)이 반환하는 컬렉션을 순회하면서 슬라이드 번호, 주석 텍스트, 작성자 이름 및 생성 시간을 출력합니다. 입력 프레젠테이션에 주석이 포함되어 있어야 콘솔 출력이 발생합니다.

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

부모 주석은 답글 계층 구조의 최상위 원래 주석을 의미합니다. [IComment.getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) 및 [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) 메서드를 사용하여 주석의 부모를 가져오거나 설정할 수 있습니다.

예제는 두 작성자의 주석을 만든 다음 [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-)을 사용해 답글을 구성하고, 또 다른 답글에 대한 답글도 생성합니다. `null`을 [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-)에 전달하면 모든 작성자의 주석을 가져옵니다; 콘솔은 답글 계층 깊이에 따라 각 항목을 들여쓰기합니다. 예제는 전체 토론을 저장하고 첫 번째 루트 주석에 대해 [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--)를 호출한 뒤 해당 주석과 그 답글이 제거된 두 번째 프레젠테이션을 저장합니다.

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

    ICommentAuthor originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    IComment secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    IComment subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    IComment separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    IComment separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

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

    rootComment.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* [IComment.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) 메서드를 사용해 주석을 삭제하면 해당 주석에 대한 모든 답글도 삭제됩니다.
* [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-)가 순환 참조를 만들 경우 [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/)이 발생합니다.
{{% /alert %}}

## **최신 주석 추가**

최신 주석은 슬라이드 자체, 특정 도형, 또는 AutoShape 내부의 텍스트 범위와 연결될 수 있습니다. [ICommentCollection.addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) 메서드는 슬라이드와 주석 마커 좌표 외에 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 인수를 추가로 받습니다.

`null`을 shape 인수에 전달하면 주석은 슬라이드 수준 주석이 됩니다. 마커는 제공된 좌표에 배치되지만 특정 도형과 연결되지 않으며, 따라서 [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--)은 `null`을 반환합니다. [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)를 제공하면 주석이 해당 도형에 고정됩니다. 좌표는 여전히 슬라이드에서 주석 마커의 위치를 정의하고, 도형 연결은 [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--)을 통해 조회할 수 있습니다.

### **도형에 최신 주석 고정**

예제는 [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-)을 두 번 호출합니다: 하나는 슬라이드 수준 주석을 위한 `null` shape이며, 다른 하나는 사각형을 앵커로 사용합니다. [getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--)을 읽어 슬라이드 수준 주석의 `null` 확인에서는 `true`가, 앵커된 주석에서는 `Revenue title`이 출력됩니다. 두 주석 모두 프레젠테이션에 저장됩니다.

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

### **다양한 도형 유형에 주석 고정**

[IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)을 구현하는 모든 슬라이드 개체를 도형 앵커로 사용할 수 있습니다. 일반적인 예로는 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnector/), 그리고 차트와 같은 [IGraphicalObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobject/) 인스턴스가 포함됩니다.

예제는 [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-)을 사용해 다섯 가지 도형 유형—AutoShape, picture frame, group, connector, chart—각각에 주석을 연결합니다. 그림은 임베드된 이미지 데이터를 사용하므로 외부 이미지가 필요하지 않습니다. 각 주석은 고유한 마커 위치를 가지며, 저장된 프레젠테이션은 다섯 도형 연결을 모두 보존합니다.

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
import android.util.Base64;
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
    byte[] imageData = Base64.decode(imageBase64, Base64.DEFAULT);
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

### **텍스트에 주석 고정 및 상태 설정**

[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)에 연결된 최신 주석의 경우, [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) 및 [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-)은 도형 텍스트 프레임 내 선택된 텍스트의 시작 위치에 접근합니다. [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) 및 [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-)은 선택 길이에 접근합니다. 이 값들을 함께 사용하면 AutoShape 내부 특정 텍스트 범위와 주석을 연결할 수 있습니다.

[IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) 및 [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) 메서드는 [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) 상수 중 하나의 값을 가져오거나 설정합니다:

- `NotDefined` — 정의된 최신 주석 상태가 없습니다.
- `Active` — 주석이 활성 상태입니다.
- `Resolved` — 주석이 해결되었습니다.
- `Closed` — 주석이 종료되었습니다.

예제는 사각형 텍스트의 "quarterly revenue" 단어에 최신 주석을 고정합니다. 텍스트에서 제로 기반 선택 시작 위치를 계산하여 [setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-)에 전달하고, [setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-)을 사용해 선택된 문자 수를 지정합니다. `Resolved`와 함께 [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-)을 호출한 뒤 프레젠테이션을 저장하고 다시 엽니다. 네 개의 콘솔 확인 모두 `true`를 출력하여 도형 앵커, 텍스트 범위 및 상태가 보존되었음을 확인합니다.

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

### **기존 최신 주석 검사**

예제는 최신 주석이 포함된 기존 프레젠테이션을 필요로 하며, 각 주석의 텍스트, 상태 및 앵커 세부 정보를 출력합니다. 이를 검사하려면 어떤 주석이 [IModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/)를 구현하는지 확인한 뒤, [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--), [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--)를 조사합니다. `null` shape은 슬라이드 수준 주석을 나타냅니다. [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) 앵커인 경우 텍스트 선택 메서드가 도형 텍스트 프레임 내 연관 범위를 식별합니다.

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

Aspose.Slides for Android via Java를 사용하면 프레젠테이션에서 모든 주석 및 작성자를 제거하거나 선택된 주석만 삭제하면서 나머지는 유지할 수 있습니다. 다음 예제는 두 가지 접근 방식을 보여주며 업데이트된 프레젠테이션을 저장합니다.

### **모든 주석 및 주석 작성자 제거**

예제는 기존 프레젠테이션을 연 뒤 각 작성자에 대해 [ICommentCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#clear--)를 호출하고, 이후 [ICommentAuthorCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#clear--)를 호출해 작성자 자체를 제거합니다. 저장된 프레젠테이션에는 주석도 작성자도 포함되지 않습니다. 제거 효과를 확인하려면 주석이 포함된 프레젠테이션을 사용하십시오.

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

예제는 하나의 슬라이드에 두 개의 주석을 만든 뒤 [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-)을 사용해 각 작성자의 주석을 찾습니다. 텍스트가 "comment 1"인 주석을 수집한 후 [ICommentCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#remove-com.aspose.slides.IComment-)을 호출해 컬렉션을 수정 중에 변경하지 않도록 합니다. 저장된 프레젠테이션에는 "comment 2"만 남습니다.

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

**Aspose.Slides가 최신 주석에 대한 해결된 상태를 지원합니까?**

예. [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) 및 [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-)를 통해 [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) 값, 즉 `Resolved`를 접근할 수 있습니다. 상태는 프레젠테이션에 저장되며 파일을 다시 열어도 읽을 수 있습니다.

**스레드형 토론(답글 체인)이 지원되며 중첩 제한이 있습니까?**

예. 각 주석은 [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--)을 참조할 수 있어 답글 체인을 구성합니다. API에서는 특정 중첩 깊이 제한을 정의하지 않습니다.

**주석 마커 위치는 슬라이드의 어떤 좌표계에 정의됩니까?**

마커 위치는 슬라이드 좌표계의 부동 소수점 좌표로 정의되며, 슬라이드에 정확히 배치할 수 있습니다.