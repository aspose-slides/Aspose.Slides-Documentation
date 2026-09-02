---
title: Node.js에서 프레젠테이션 댓글 관리
linktitle: 프레젠테이션 댓글
type: docs
weight: 100
url: /ko/nodejs-java/presentation-comments/
keywords:
- 댓글
- 모던 댓글
- PowerPoint 댓글
- 프레젠테이션 댓글
- 슬라이드 댓글
- 댓글 추가
- 댓글 접근
- 댓글 편집
- 댓글 답글
- 댓글 삭제
- 댓글 삭제
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 프레젠테이션에서 프레젠테이션 댓글을 관리합니다: 추가, 읽기, 편집, 답글 달기 및 삭제."
---
## **개요**

이 문서는 Aspose.Slides for Node.js via Java를 사용하여 프레젠테이션 댓글을 관리하는 방법을 설명합니다. 주요 댓글 관련 유형을 소개하고 슬라이드에 댓글을 추가하고, 기존 댓글에 액세스하고, 답글 및 현대식 댓글을 다루며, 프레젠테이션에서 댓글을 제거하는 방법을 시연합니다.

예제는 PowerPoint에서 일반적인 검토 및 협업 시나리오를 다룹니다. 예를 들어 작성자에게 댓글을 할당하고, 댓글 텍스트와 메타데이터를 읽고, 답글 체인을 구성하고, 선택된 댓글 또는 모든 댓글을 제거하는 작업을 포함합니다.

PowerPoint에서 댓글은 슬라이드에 표시되는 주석 형태로 나타납니다. 댓글을 선택하면 해당 텍스트와 관련 토론이 표시됩니다.

## **왜 프레젠테이션에 댓글을 추가하나요?**

프레젠테이션을 검토할 때 피드백을 제공하고 동료와 협업하기 위해 댓글을 사용할 수 있습니다.

Aspose.Slides for Node.js via Java는 댓글 작업을 위한 다음 API를 제공합니다:

* [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스 – 프레젠테이션의 댓글 작성자에 대한 접근을 제공합니다.
* [CommentCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/commentcollection/) 클래스 – 개별 작성자와 연관된 댓글을 나타냅니다.
* [Comment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/comment/) 클래스 – 작성자, 생성 시간, 위치 및 텍스트 등 댓글에 대한 정보를 제공합니다.
* [CommentAuthor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/commentauthor/) 클래스 – 이름, 이니셜 및 연관된 댓글을 포함한 작성자 정보를 제공합니다.

## **슬라이드 댓글 추가**

다음 예제는 PowerPoint 프레젠테이션에 슬라이드 댓글을 추가하는 방법을 보여줍니다:

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

## **슬라이드 댓글 액세스**

다음 예제는 PowerPoint 프레젠테이션에서 기존 댓글에 액세스하는 방법을 보여줍니다:

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

## **댓글에 답글 달기**

상위 댓글은 답글 계층 구조의 최상위 원본 댓글입니다. [Comment.getParentComment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/comment/getparentcomment/) 및 [Comment.setParentComment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/comment/setparentcomment/) 메서드를 사용하면 댓글의 상위 댓글을 가져오거나 설정할 수 있습니다.

다음 예제는 답글을 추가하고 결과 댓글 계층 구조를 검사하는 방법을 보여줍니다:

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
* [Comment.remove](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/comment/remove/) 메서드를 사용해 댓글을 삭제하면 해당 댓글에 대한 모든 답글도 함께 삭제됩니다.  
* [Comment.setParentComment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/comment/setparentcomment/) 가 순환 참조를 생성하면 [PptxEditException](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptxeditexception/) 이 발생합니다.
{{% /alert %}}

## **모던 댓글 추가**

모던 댓글은 슬라이드 자체, 특정 Shape, 또는 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/) 내부의 텍스트 범위와 연결될 수 있습니다. [CommentCollection.addModernComment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) 메서드는 슬라이드와 댓글 마커 좌표 외에 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/) 인수를 추가로 받습니다.

`null`을 Shape 인수로 전달하면 댓글은 슬라이드 수준 댓글이 됩니다. 마커는 제공된 좌표에 따라 배치되지만 특정 Shape와 연결되지 않으므로 [ModernComment.getShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/getshape/) 은 `null` 을 반환합니다. [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/) 를 제공하면 댓글이 해당 Shape에 고정됩니다. 좌표는 여전히 슬라이드상의 마커 위치를 정의하며, Shape 연관은 [ModernComment.getShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/getshape/) 로 조회할 수 있습니다.

### **모던 댓글을 Shape에 고정하기**

다음 예제는 슬라이드 수준 모던 댓글과 특정 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)에 고정된 모던 댓글을 모두 생성하고 각 댓글에서 연관된 Shape를 읽습니다.

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

### **다양한 Shape 유형에 댓글 고정**

[Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/) 에서 파생된 모든 슬라이드 객체는 Shape 고정용으로 사용할 수 있습니다. 일반적인 예로 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/connector/), 차트와 같은 [GraphicalObject](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/graphicalobject/) 인스턴스가 있습니다.

다음 예제는 여러 일반적인 Shape 유형을 생성하고 각각에 모던 댓글을 연결합니다.

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

### **텍스트에 댓글 고정 및 상태 설정**

[AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)에 연결된 모던 댓글의 경우, [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) 및 [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) 은 Shape의 텍스트 프레임에서 선택된 텍스트의 시작 위치에 접근합니다. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) 및 [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) 은 선택 길이에 접근합니다. 이 값들을 결합하면 댓글을 해당 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/) 내부의 특정 텍스트 범위와 연결할 수 있습니다.

[ModernComment.getStatus](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/getstatus/) 및 [ModernComment.setStatus](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/setstatus/) 메서드는 [ModernCommentStatus](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncommentstatus/) 열거형의 값을 접근합니다:

- `NotDefined` — 특정 모던 댓글 상태가 정의되지 않았음.  
- `Active` — 댓글이 활성 상태임.  
- `Resolved` — 댓글이 해결됨.  
- `Closed` — 댓글이 닫힘.

다음 예제는 Shape에 고정된 모던 댓글을 생성하고, 텍스트 선택과 연결하며, 해결된 상태로 표시하고, 프레젠테이션을 저장한 뒤 파일을 다시 연 후 값을 확인합니다.

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

### **기존 모던 댓글 검사**

기존 프레젠테이션을 검사하려면 어떤 댓글이 [ModernComment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/) 인스턴스인지 확인하고, 이후 [ModernComment.getShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/), [ModernComment.getStatus](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/getstatus/) 를 검토합니다. `null` Shape 은 슬라이드 수준 댓글을 나타냅니다. [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)에 고정된 경우 텍스트 선택 메서드가 Shape 텍스트 프레임 내 연관 범위를 식별합니다.

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

## **댓글 삭제**

### **모든 댓글 및 댓글 작성자 삭제**

다음 예제는 프레젠테이션에서 모든 댓글과 댓글 작성자를 삭제하는 방법을 보여줍니다:

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

### **특정 댓글 삭제**

다음 예제는 슬라이드에서 특정 댓글을 삭제하는 방법을 보여줍니다:

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

**Aspose.Slides가 모던 댓글에 대한 해결 상태를 지원하나요?**

네. [ModernComment.getStatus](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/getstatus/) 및 [ModernComment.setStatus](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/setstatus/) 은 `Resolved` 를 포함한 [ModernCommentStatus](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncommentstatus/) 값을 접근합니다. 상태는 프레젠테이션에 저장되며 파일을 다시 열었을 때 다시 읽을 수 있습니다.

**스레드형 토론(답글 체인)이 지원되며, 중첩 제한이 있나요?**

네. 각 댓글은 [parent comment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/comment/getparentcomment/) 을 참조할 수 있어 답글 체인을 만들 수 있습니다. API에서는 특정 중첩 깊이 제한을 정의하지 않습니다.

**슬라이드에서 댓글 마커 위치는 어떤 좌표계로 정의됩니까?**

마커 위치는 슬라이드 좌표계의 부동 소수점 좌표로 정의되어 슬라이드 내 원하는 정확한 위치에 배치할 수 있습니다.