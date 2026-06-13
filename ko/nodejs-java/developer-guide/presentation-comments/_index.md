---
title: JavaScript에서 프레젠테이션 주석 관리
linktitle: 프레젠테이션 주석
type: docs
weight: 100
url: /ko/nodejs-java/presentation-comments/
keywords:
- 주석
- 모던 주석
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
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 프레젠테이션 주석을 마스터하세요: JavaScript로 PowerPoint 파일에서 주석을 추가, 읽기, 편집 및 삭제를 빠르고 쉽게 수행합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 프레젠테이션 주석을 관리하는 방법을 설명합니다. 주요 주석 관련 유형을 보여주고 슬라이드에 주석을 추가하고, 기존 주석에 접근하고, 답글 작업을 수행하고, 최신 주석을 사용하며, 프레젠테이션에서 주석을 제거하는 방법을 시연합니다.

예제는 PowerPoint에서 일반적인 검토 및 협업 시나리오에 중점을 두며, 저자에게 주석을 할당하고, 주석 내용 및 메타데이터를 읽으며, 답글 체인을 구축하고, 모든 주석을 지우거나 선택된 주석을 삭제하는 방법을 다룹니다.

PowerPoint에서 주석은 슬라이드 위의 메모 또는 주석으로 표시됩니다. 주석을 클릭하면 해당 내용이나 메시지가 표시됩니다.

## **왜 프레젠테이션에 주석을 추가합니까?**

프레젠테이션을 검토할 때 피드백을 제공하거나 동료와 소통하기 위해 주석을 사용할 수 있습니다.

PowerPoint 프레젠테이션에서 주석을 사용할 수 있도록 Aspose.Slides for Node.js via Java는 다음을 제공합니다.

* The [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스는 저자 컬렉션을 포함합니다([CommentAuthorCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/CommentAuthorCollection) 클래스에서 가져옴). 저자는 슬라이드에 주석을 추가합니다.
* The [CommentCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/CommentCollection) 클래스는 개별 저자에 대한 주석 컬렉션을 포함합니다.
* The [Comment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Comment) 클래스는 저자와 그들의 주석에 대한 정보(주석을 추가한 사람, 주석이 추가된 시간, 주석 위치 등)를 포함합니다.
* The [CommentAuthor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/CommentAuthor) 클래스는 개별 저자에 대한 정보(저자 이름, 이니셜, 해당 이름에 연결된 주석 등)를 포함합니다.

## **슬라이드 주석 추가**

다음 JavaScript 코드는 PowerPoint 프레젠테이션의 슬라이드에 주석을 추가하는 방법을 보여줍니다:

```javascript
// Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 빈 슬라이드를 추가합니다
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // 작성자를 추가합니다
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // 주석 위치를 설정합니다
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // 슬라이드 1에 작성자를 위한 슬라이드 주석을 추가합니다
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // 슬라이드 2에 작성자를 위한 슬라이드 주석을 추가합니다
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // ISlide 1에 접근합니다
    var slide = pres.getSlides().get_Item(0);
    // 인자로 null을 전달하면 모든 작성자의 주석이 선택된 슬라이드에 가져와집니다
    var Comments = slide.getSlideComments(author);
    // 슬라이드 1의 인덱스 0에 있는 주석에 접근합니다
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // 인덱스 0에 있는 작성자의 주석 컬렉션을 선택합니다
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **슬라이드 주석 접근**

다음 JavaScript 코드는 PowerPoint 프레젠테이션의 슬라이드에 있는 기존 주석에 접근하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **주석에 답글 달기**

부모 주석은 주석 또는 답글 계층 구조에서 최상위 또는 원본 주석입니다. [getParentComment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Comment#getParentComment--) 또는 [setParentComment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) 메서드([Comment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Comment) 클래스에서)를 사용하여 부모 주석을 설정하거나 가져올 수 있습니다.

다음 JavaScript 코드는 주석을 추가하고 해당 주석에 대한 답글을 가져오는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 주석을 추가합니다
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // comment1에 대한 답글을 추가합니다
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // comment1에 또 다른 답글을 추가합니다
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // 기존 답글에 대한 답글을 추가합니다
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // 콘솔에 주석 계층 구조를 표시합니다
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // comment1 및 그에 대한 모든 답글을 제거합니다
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" title="Attention" %}} 
* [Remove](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Comment#remove--) 메서드([Comment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Comment) 클래스에서)를 사용하여 주석을 삭제하면 해당 주석에 대한 답글도 함께 삭제됩니다.
* [setParentComment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) 설정이 순환 참조를 일으키면 [PptxEditException](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PptxEditException)가 발생합니다.
{{% /alert %}}

## **모던 주석 추가**

2021년에 Microsoft는 PowerPoint에 *모던 주석*을 도입했습니다. 모던 주석 기능은 PowerPoint에서 협업을 크게 향상시킵니다. 모던 주석을 통해 PowerPoint 사용자는 주석을 해결하고, 주석을 개체와 텍스트에 고정하며, 이전보다 훨씬 쉽게 상호작용할 수 있습니다. 

Aspose.Slides는 [ModernComment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ModernComment) 클래스를 통해 모던 주석을 지원합니다. [addModernComment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) 및 [insertModernComment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) 메서드가 [CommentCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/CommentCollection) 클래스에 추가되었습니다.

다음 JavaScript 코드는 PowerPoint 프레젠테이션의 슬라이드에 모던 주석을 추가하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **주석 제거**

### **모든 주석 및 저자 삭제**

다음 JavaScript 코드는 프레젠테이션에서 모든 주석 및 저자를 제거하는 방법을 보여줍니다:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // 프레젠테이션에서 모든 주석을 삭제합니다
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // 모든 저자를 삭제합니다
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **특정 주석 삭제**

다음 JavaScript 코드는 슬라이드에서 특정 주석을 삭제하는 방법을 보여줍니다:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // 주석을 추가합니다...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // "comment 1" 텍스트를 포함하는 모든 주석을 제거합니다
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **자주 묻는 질문**

**Aspose.Slides는 모던 주석에 '해결됨'과 같은 상태를 지원합니까?**

예. [Modern comments](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/)은 [getStatus](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/getstatus/) 및 [setStatus](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncomment/setStatus/) 메서드를 제공하며, [comment’s state](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/moderncommentstatus/)를 읽고 설정할 수 있습니다(예: 해결됨으로 표시). 이 상태는 파일에 저장되고 PowerPoint에서 인식됩니다.

**스레드형 토론(답글 체인)이 지원되며, 중첩 제한이 있나요?**

예. 각 주석은 자신의 [parent comment](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/comment/getparentcomment/)을 참조할 수 있어 任意의 답글 체인을 만들 수 있습니다. API에서는 특정 중첩 깊이 제한을 선언하지 않습니다.

**슬라이드에서 주석 마커 위치는 어떤 좌표계로 정의됩니까?**

위치는 슬라이드 좌표계의 부동 소수점 좌표로 저장됩니다. 이를 통해 주석 마커를 원하는 정확한 위치에 배치할 수 있습니다.