---
title: Node.js에서 프레젠테이션 주석 관리
linktitle: 프레젠테이션 주석
type: docs
weight: 100
url: /ko/nodejs-java/presentation-comments/
keywords:
- 주석
- 최신 주석
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 프레젠테이션 주석을 관리합니다: PowerPoint 프레젠테이션에서 주석을 추가, 읽기, 편집, 답글 달기 및 제거합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Node.js via Java를 사용하여 프레젠테이션 주석을 관리하는 방법을 설명합니다. 주요 주석 관련 유형을 소개하고 슬라이드에 주석을 추가하고, 기존 주석에 접근하고, 답글 및 최신 주석을 작업하며, 프레젠테이션에서 주석을 제거하는 방법을 보여줍니다.

예제는 PowerPoint에서 일반적인 검토 및 협업 시나리오를 다룹니다. 예를 들어 작성자에게 주석을 할당하고, 주석 텍스트와 메타데이터를 읽으며, 답글 체인을 구성하고, 선택된 주석이나 모든 주석을 제거하는 방법 등을 포함합니다.

PowerPoint에서 주석은 슬라이드의 주석(Annotation)으로 표시됩니다. 주석을 선택하면 텍스트와 관련 토론이 표시됩니다.

프레젠테이션을 열 때 주석을 표시하거나 숨기려면(주석 자체를 변경하지 않고) [프레젠테이션 열 때 주석 표시 또는 숨기기](/slides/ko/nodejs-java/presentation-view-properties/)를 참조하십시오.

## **프레젠테이션에 주석을 추가하는 이유**

프레젠테이션을 검토할 때 피드백을 제공하고 동료와 협업하려면 주석을 사용할 수 있습니다.

Aspose.Slides for Node.js via Java는 주석 작업을 위한 다음 API를 제공합니다.

* 프레젠테이션의 주석 작성자에 접근할 수 있는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스.
* 개별 작성자와 연결된 주석을 나타내는 [CommentCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/commentcollection/) 클래스.
* 작성자, 생성 시간, 위치 및 텍스트 등 주석에 대한 정보를 제공하는 [Comment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/comment/) 클래스.
* 이름, 이니셜 및 연결된 주석 등 작성자에 대한 정보를 제공하는 [CommentAuthor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/commentauthor/) 클래스.

## **슬라이드 주석 추가**

다음 예제는 PowerPoint 프레젠테이션의 슬라이드에 주석을 추가하는 방법을 보여줍니다:

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

## **슬라이드 주석 접근**

다음 예제는 PowerPoint 프레젠테이션에서 기존 주석에 접근하는 방법을 보여줍니다:

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

## **주석에 답글 달기**

부모 주석은 답글 계층 구조의 최상위에 위치한 원래 주석을 의미합니다. [Comment.getParentComment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/comment/getparentcomment/) 및 [Comment.setParentComment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/comment/setparentcomment/) 메서드를 사용하면 주석의 부모를 가져오거나 설정할 수 있습니다.

다음 예제는 답글을 추가하고 결과 주석 계층 구조를 검사하는 방법을 보여줍니다:

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
* [Comment.remove](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/comment/remove/) 메서드로 주석을 삭제하면 해당 주석에 대한 모든 답글도 삭제됩니다.
* [Comment.setParentComment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/comment/setparentcomment/)가 순환 참조를 만들 경우 [PptxEditException](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pptxeditexception/)이 발생합니다.
{{% /alert %}}

## **최신 주석 추가**

최신 주석은 슬라이드 자체, 특정 도형, 또는 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/) 내부의 텍스트 범위에 연결될 수 있습니다. [CommentCollection.addModernComment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) 메서드는 슬라이드와 주석 마커 좌표 외에 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/) 인수를 추가로 받습니다.

`null`을 shape 인수로 전달하면 주석은 슬라이드 수준 주석이 됩니다. 마커는 제공된 좌표에 따라 배치되지만 특정 도형과 연결되지 않으므로 [ModernComment.getShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/getshape/)은 `null`을 반환합니다. [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/)가 제공되면 주석은 해당 도형에 고정됩니다. 좌표는 여전히 슬라이드상의 마커 위치를 정의하고, 도형 연관성은 [ModernComment.getShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/getshape/)을 통해 검색할 수 있습니다.

### **현대 주석을 도형에 고정**

다음 예제는 슬라이드 수준 최신 주석과 특정 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)에 고정된 최신 주석을 모두 만든 후, 각 주석에서 연관된 도형을 읽어옵니다.

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

### **다양한 도형 유형에 주석 고정**

[Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/)에서 파생된 모든 슬라이드 개체는 도형 고정점으로 사용할 수 있습니다. 일반적인 예로는 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/connector/), 차트와 같은 [GraphicalObject](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/graphicalobject/) 인스턴스가 있습니다.

다음 예제는 여러 일반 도형 유형을 만들고 각각에 최신 주석을 연결합니다.

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

### **텍스트에 주석 고정 및 상태 설정**

[AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)에 연결된 최신 주석의 경우, [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) 및 [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/settextselectionstart/)는 도형의 텍스트 프레임에서 선택된 텍스트의 시작 위치에 접근합니다. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) 및 [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/settextselectionlength/)는 선택 영역의 길이를 반환합니다. 이 값들을 함께 사용하면 주석을 특정 텍스트 범위와 연결할 수 있습니다.

[ModernComment.getStatus](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/getstatus/) 및 [ModernComment.setStatus](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/setstatus/) 메서드는 [ModernCommentStatus](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncommentstatus/) 열거형 값에 접근합니다.

- `NotDefined` — 정의된 현대 주석 상태가 없음.
- `Active` — 주석이 활성 상태.
- `Resolved` — 주석이 해결됨.
- `Closed` — 주석이 종료됨.

다음 예제는 도형에 고정된 최신 주석을 만들고, 텍스트 선택에 연결하고, 해결된 상태로 표시한 뒤 프레젠테이션을 저장하고 파일을 다시 열어 값을 검증합니다.

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

### **기존 최신 주석 검사**

기존 프레젠테이션을 검사하려면 어떤 주석이 [ModernComment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/) 인스턴스인지 확인한 뒤, [ModernComment.getShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/), [ModernComment.getStatus](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/getstatus/)를 검사합니다. `null` 도형은 슬라이드 수준 주석을 나타냅니다. [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)에 고정된 경우 텍스트 선택 메서드가 도형 텍스트 프레임 내 연결된 범위를 식별합니다.

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

## **주석 제거**

### **모든 주석 및 주석 작성자 제거**

다음 예제는 프레젠테이션에서 모든 주석과 주석 작성자를 제거하는 방법을 보여줍니다:

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

### **특정 주석 제거**

다음 예제는 슬라이드에서 특정 주석을 제거하는 방법을 보여줍니다:

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

**Aspose.Slides에서 최신 주석의 해결 상태를 지원합니까?**

예. [ModernComment.getStatus](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/getstatus/) 및 [ModernComment.setStatus](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/setstatus/)는 `Resolved`를 포함한 [ModernCommentStatus](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncommentstatus/) 값을 접근합니다. 이 상태는 프레젠테이션에 저장되며 파일을 다시 연 후에도 읽을 수 있습니다.

**스레드 형식 토론(답글 체인)이 지원되며 중첩 제한이 있습니까?**

예. 각 주석은 [parent comment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/comment/getparentcomment/)를 참조할 수 있어 답글 체인을 만들 수 있습니다. API에서는 특정 중첩 깊이 제한을 정의하지 않습니다.

**주석 마커 위치는 슬라이드의 어떤 좌표계로 정의됩니까?**

마커 위치는 슬라이드 좌표계의 부동 소수점 좌표로 정의되어 슬라이드 위에 정확히 배치할 수 있습니다.