---
title: Node.js에서 프레젠테이션 주석 관리
linktitle: 프레젠테이션 주석
type: docs
weight: 100
url: /ko/nodejs-java/presentation-comments/
keywords:
- 주석
- 현대식 주석
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
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 프레젠테이션에서 프레젠테이션 주석을 관리합니다: 주석 추가, 읽기, 편집, 답글 달기 및 제거."
---
## **개요**

이 문서는 Aspose.Slides for Node.js via Java를 사용하여 프레젠테이션 주석을 관리하는 방법을 설명합니다. 주요 주석 관련 타입을 소개하고 슬라이드에 주석을 추가하고, 기존 주석에 접근하고, 답글 및 최신 주석을 처리하며, 프레젠테이션에서 주석을 제거하는 방법을 보여줍니다.

예제는 PowerPoint에서 일반적인 검토 및 협업 시나리오를 다루며, 작성자에게 주석을 할당하고, 주석 텍스트와 메타데이터를 읽고, 답글 체인을 구축하고, 선택된 주석 또는 모든 주석을 제거하는 방법을 포함합니다.

PowerPoint에서 주석은 슬라이드의 주석(annotations)으로 표시됩니다. 주석을 선택하면 해당 텍스트와 관련 토론이 표시됩니다.

프레젠테이션을 열 때 주석을 표시하거나 숨기도록 요청하려면, 주석 자체를 변경하지 않고 [Show or Hide Comments When Opening a Presentation](/slides/ko/nodejs-java/presentation-view-properties/)를 참조하세요.

## **프레젠테이션에 주석을 추가하는 이유는?**

프레젠테이션을 검토할 때 피드백을 제공하고 동료와 협업하기 위해 주석을 사용할 수 있습니다.

Aspose.Slides for Node.js via Java는 주석 작업을 위한 다음 API를 제공합니다:

* The [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 클래스는 프레젠테이션의 주석 작성자에 대한 액세스를 제공합니다.
* The [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/) 클래스는 개별 작성자와 연결된 주석을 나타냅니다.
* The [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/) 클래스는 작성자, 생성 시간, 위치 및 텍스트를 포함한 주석 정보를 제공합니다.
* The [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/) 클래스는 이름, 이니셜 및 연결된 주석을 포함한 작성자 정보를 제공합니다.

## **슬라이드 주석 추가**

예제는 두 개의 슬라이드를 만들고 [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/)로 주석 작성자를 등록합니다. 각 슬라이드에 하나씩 주석을 배치하기 위해 [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/)를 사용하고, 해당 작성자에 대한 첫 번째 슬라이드의 주석을 [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/)로 가져옵니다. 콘솔은 첫 번째 주석의 텍스트를 두 번 표시하여 슬라이드와 작성자 모두를 통해 접근함을 보여주며, 저장된 프레젠테이션에는 두 주석이 모두 포함됩니다.

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

## **주석 작성자 찾기 또는 만들기**

자동 검토가 동일한 프레젠테이션을 반복적으로 처리할 경우, 작성자를 추가하기 전에 [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/)가 반환하는 컬렉션을 검색합니다. [findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/)는 이름과 이니셜을 모두 일치시키고 일치하는 작성자 배열을 반환하며, 일치하는 항목이 없으면 빈 배열을 반환합니다. 반면에 [findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/)는 이니셜에 관계없이 이름만으로 검색합니다. 이미 컬렉션에 존재하는 이름과 이니셜으로 [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/)를 호출하면 예외가 발생합니다.

예제는 최소 하나의 슬라이드가 포함된 프레젠테이션 파일이 필요합니다. 두 번의 패스 각각에서 첫 번째 일치하는 작성자를 재사용하거나, 결과가 비어 있을 때만 새로 만듭니다. 일치하는 작성자가 여러 개이면 다른 작성자를 병합하거나 제거하지 않고 첫 번째 배열 요소를 선택합니다. 그런 다음 선택된 작성자에 대해 [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/)을 호출하고 프레젠테이션을 저장합니다. 두 번째 패스는 첫 번째 패스의 출력을 열어 동일한 작업을 반복합니다.

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

두 번째 패스는 다른 작성자를 추가하거나 기존 주석을 제거하지 않고 또 다른 주석을 추가합니다. 최종 파일 `review_pass_2.pptx`에는 원본 주석과 함께 두 개의 새로운 주석이 모두 포함됩니다. 작성자를 재사용한다고 해서 주석이 중복 제거되는 것은 아니므로, 동일한 주석을 반복해서 추가하지 않으려면 추가하기 전에 별도의 중복 감지를 구현해야 합니다.

## **슬라이드 주석 접근**

예제는 기존 프레젠테이션을 열고 [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/)가 반환하는 컬렉션을 읽습니다. 각 작성자에 대해 [getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/)가 반환하는 컬렉션을 순회하면서 슬라이드 번호, 주석 텍스트, 작성자 이름 및 생성 시간을 출력합니다. 입력 프레젠테이션에 주석이 포함되어 있어야 콘솔 출력이 생성됩니다.

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

상위 주석은 답글 계층 구조의 최상위 원본 주석을 의미합니다. [Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) 및 [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) 메서드를 사용하면 주석의 상위 주석을 가져오거나 설정할 수 있습니다.

예제는 두 명의 작성자로부터 주석을 생성하고 [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/)을 사용해 답글을 구축하며, 다른 답글에 대한 답글도 포함합니다. `null`을 [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/)에 전달하면 모든 작성자의 주석을 검색합니다. 콘솔은 답글 계층의 깊이에 따라 각 항목을 들여쓰기합니다. 예제는 전체 토론을 저장하고, 첫 번째 루트 주석에 대해 [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/)를 호출한 뒤 해당 주석과 그 답글이 제거된 두 번째 프레젠테이션을 저장합니다.

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
* [Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) 메서드를 사용해 주석을 삭제하면 해당 주석에 대한 모든 답글도 함께 삭제됩니다.
* [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/)가 순환 참조를 생성하면 [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/)이 발생합니다.
{{% /alert %}}

## **현대식 주석 추가**

현대식 주석은 슬라이드 자체, 특정 도형, 또는 AutoShape 내부의 텍스트 범위와 연결될 수 있습니다. [CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) 메서드는 슬라이드와 주석 마커 좌표 외에 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 인수를 허용합니다.

`null`을 shape 인수에 전달하면 주석은 슬라이드 수준 주석이 됩니다. 마커는 제공된 좌표에 배치되지만 특정 도형에 연결되지 않으므로 [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/)은 `null`을 반환합니다. [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)가 제공되면 주석은 해당 도형에 고정됩니다. 좌표는 여전히 슬라이드상의 주석 마커 위치를 정의하고, 도형 연결은 [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/)을 통해 검색할 수 있습니다.

### **도형에 현대식 주석 고정**

예제는 [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/)을 두 번 호출합니다. 첫 번째는 슬라이드 수준 주석을 위해 `null` shape를 사용하고, 두 번째는 사각형을 고정점으로 사용합니다. [getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/)을 읽어 슬라이드 수준 주석의 null 체크는 `true`를, 고정된 주석은 `Revenue title`을 출력합니다. 두 주석 모두 프레젠테이션에 저장됩니다.

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

[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)에서 파생된 모든 슬라이드 객체를 도형 고정점으로 사용할 수 있습니다. 일반적인 예로는 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/), 그리고 차트와 같은 [GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/) 인스턴스가 포함됩니다.

예제는 [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/)을 사용해 다섯 가지 도형 유형(자동 도형, 그림 프레임, 그룹, 커넥터, 차트) 각각에 주석을 연결합니다. 그림은 임베드된 이미지 데이터를 사용하므로 외부 이미지가 필요하지 않습니다. 각 주석은 자체 마커 위치를 가지고 있으며, 저장된 프레젠테이션은 다섯 도형 연결을 모두 유지합니다.

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

[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)에 연결된 현대식 주석의 경우, [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) 및 [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/)는 도형 텍스트 프레임에서 선택된 텍스트의 시작 위치에 접근합니다. [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) 및 [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/)는 선택 길이에 접근합니다. 이 값들을 함께 사용하면 주석을 자동 도형 내부의 특정 텍스트 범위와 연결할 수 있습니다.

[ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) 및 [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) 메서드는 [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) 열거형의 값을 가져옵니다:

- `NotDefined` — 특정 현대식 주석 상태가 정의되지 않음.
- `Active` — 주석이 활성화됨.
- `Resolved` — 주석이 해결됨.
- `Closed` — 주석이 닫힘.

예제는 사각형 텍스트의 "quarterly revenue" 단어에 현대식 주석을 고정합니다. 텍스트에서 0부터 시작하는 선택 시작 위치를 계산하고 이를 [setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/)에 전달하고, [setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/)을 사용해 선택된 문자 수를 설정합니다. `Resolved` 상태로 [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/)를 호출한 뒤 프레젠테이션을 저장하고 다시 열면 네 번의 콘솔 확인 모두 `true`를 출력하여 도형 고정, 텍스트 범위 및 상태가 보존됨을 확인합니다.

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

### **기존 현대식 주석 검사**

예제는 현대식 주석이 포함된 기존 프레젠테이션을 필요로 하며, 텍스트, 상태 및 고정 세부 정보를 출력합니다. 이를 검사하려면 주석이 [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/) 인스턴스인지 확인한 뒤, [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/), 그리고 [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/)을 검사합니다. `null` shape는 슬라이드 수준 주석임을 나타냅니다. [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) 고정의 경우, 텍스트 선택 메서드가 도형 텍스트 프레임 내의 관련 범위를 식별합니다.

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

Aspose.Slides for Node.js via Java를 사용하면 프레젠테이션에서 모든 주석 및 작성자를 제거하거나, 나머지를 유지하면서 선택된 주석만 삭제할 수 있습니다. 다음 예제들은 두 가지 접근 방식을 보여주며, 업데이트된 프레젠테이션을 저장합니다.

### **모든 주석 및 주석 작성자 제거**

예제는 기존 프레젠테이션을 열고 각 작성자에 대해 [CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/)를 호출한 뒤, [CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/)를 호출해 작성자 자체를 제거합니다. 저장된 프레젠테이션에는 주석도 작성자도 포함되지 않습니다. 주석이 포함된 프레젠테이션을 사용해 제거 효과를 확인하세요.

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

예제는 하나의 슬라이드에 두 개의 주석을 만들고 [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/)를 사용해 각 작성자의 주석을 찾습니다. 텍스트가 "comment 1"과 일치하는 주석을 수집한 뒤 [CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/)를 호출하여 선택 중 컬렉션이 변경되는 것을 방지합니다. 저장된 프레젠테이션에는 "comment 2"만 남습니다.

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

**Aspose.Slides가 현대식 주석에 대한 해결(Resolved) 상태를 지원하나요?**

예. [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) 및 [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/)는 `Resolved`를 포함한 [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) 값을 접근합니다. 상태는 프레젠테이션에 저장되며 파일을 다시 열었을 때 다시 읽을 수 있습니다.

**스레드형 토론(답글 체인)이 지원되며, 중첩 제한이 있나요?**

예. 각 주석은 [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/)를 참조할 수 있어 답글 체인을 만들 수 있습니다. API에서는 특정 중첩 깊이 제한을 정의하지 않습니다.

**슬라이드에서 주석 마커 위치는 어떤 좌표계로 정의되나요?**

마커 위치는 슬라이드 좌표계의 부동소수점 좌표로 정의되며, 슬라이드 내에서 정확히 배치할 수 있습니다.