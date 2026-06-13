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
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용해 프레젠테이션 댓글을 마스터하세요: PowerPoint 파일에서 댓글을 빠르고 쉽게 추가, 읽기, 편집 및 삭제합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 프레젠테이션 댓글을 관리하는 방법을 설명합니다. 주요 댓글 관련 유형을 보여주고 슬라이드에 댓글을 추가하고, 기존 댓글에 접근하고, 답글을 작업하고, 최신 댓글을 사용하며, 프레젠테이션에서 댓글을 제거하는 방법을 시연합니다.

예제는 PowerPoint의 일반적인 검토 및 협업 시나리오에 중점을 두며, 저자에게 댓글을 할당하고, 댓글 내용 및 메타데이터를 읽고, 답글 체인을 구성하며, 모든 댓글을 삭제하거나 선택된 댓글만 삭제하는 작업을 포함합니다.

PowerPoint에서 댓글은 슬라이드의 메모나 주석 형태로 나타납니다. 댓글을 클릭하면 해당 내용이나 메시지가 표시됩니다.

## **왜 프레젠테이션에 댓글을 추가합니까?**

프레젠테이션을 검토할 때 피드백을 제공하거나 동료와 소통하기 위해 댓글을 사용할 수 있습니다.

PowerPoint 프레젠테이션에서 댓글을 사용할 수 있도록 Aspose.Slides for Java는 다음을 제공합니다:

* [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스는 저자 컬렉션([ICommentAuthorCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ICommentAuthorCollection) 인터페이스에서 가져옴)을 포함합니다. 저자는 슬라이드에 댓글을 추가합니다.
* [ICommentCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ICommentCollection) 인터페이스는 개별 저자에 대한 댓글 컬렉션을 포함합니다.
* [IComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IComment) 클래스는 저자와 그들의 댓글에 대한 정보를 포함합니다: 누가 댓글을 추가했는지, 댓글이 추가된 시간, 댓글 위치 등.
* [CommentAuthor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/CommentAuthor) 클래스는 개별 저자에 대한 정보를 포함합니다: 저자 이름, 이니셜, 해당 저자와 연결된 댓글 등.

## **슬라이드 댓글 추가**
다음 Java 코드는 PowerPoint 프레젠테이션의 슬라이드에 댓글을 추가하는 방법을 보여줍니다:

```java
    // Presentation 클래스를 인스턴스화합니다
    Presentation pres = new Presentation();
    try {
        // 빈 슬라이드를 추가합니다
        pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

        // 작성자를 추가합니다
        ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

        // 댓글 위치를 설정합니다
        Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

        // 슬라이드 1에 작성자의 슬라이드 댓글을 추가합니다
        author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

        // 슬라이드 2에 작성자의 슬라이드 댓글을 추가합니다
        author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

        // ISlide 1에 접근합니다
        ISlide slide = pres.getSlides().get_Item(0);

        // 인자로 null을 전달하면 모든 작성자의 댓글이 선택된 슬라이드에 가져와집니다
        IComment[] Comments = slide.getSlideComments(author);

        // 슬라이드 1의 인덱스 0에 있는 댓글에 접근합니다
        String str = Comments[0].getText();

        pres.save("Comments_out.pptx", SaveFormat.Pptx);

        if (Comments.length > 0)
        {
            // 작성자 인덱스 0의 댓글 컬렉션을 선택합니다
            ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
            String Comment = commentCollection.get_Item(0).getText();
        }
    } finally {
        if (pres != null) pres.dispose();
    }
```

## **슬라이드 댓글 접근**
다음 Java 코드는 PowerPoint 프레젠테이션의 슬라이드에 존재하는 댓글에 접근하는 방법을 보여줍니다:

```java
// Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **댓글에 답글 달기**
부모 댓글은 댓글 또는 답글 계층 구조에서 최상위 또는 원본 댓글입니다. [getParentComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IComment#getParentComment--) 또는 [setParentComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) 메서드([IComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IComment) 인터페이스)를 사용하여 부모 댓글을 설정하거나 가져올 수 있습니다.

다음 Java 코드는 댓글을 추가하고 해당 댓글에 대한 답글을 가져오는 방법을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    // 댓글을 추가합니다
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // comment1에 대한 답글을 추가합니다
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // comment1에 대한 또 다른 답글을 추가합니다
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // 기존 답글에 대한 답글을 추가합니다
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // 콘솔에 댓글 계층 구조를 표시합니다
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // comment1과 그에 대한 모든 답글을 제거합니다
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Attention" %}} 
* 댓글을 삭제하기 위해 [Remove](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IComment#remove--) 메서드(IComment 인터페이스)를 사용하면 해당 댓글에 대한 답글도 삭제됩니다. 
* [setParentComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) 설정이 순환 참조를 일으키면 [PptxEditException](https://reference.aspose.com/slides/ko/java/com.aspose.slides/PptxEditException)가 발생합니다.
{{% /alert %}}

## **최신 댓글 추가**
2021년 Microsoft는 PowerPoint에 *현대식 댓글*을 도입했습니다. 현대식 댓글 기능은 PowerPoint에서 협업을 크게 향상시킵니다. 현대식 댓글을 통해 PowerPoint 사용자는 댓글을 해결하고, 댓글을 개체 및 텍스트에 고정하며, 이전보다 훨씬 쉽게 상호 작용할 수 있습니다.

[Aspose Slides for Java 21.11](https://docs.aspose.com/slides/ko/java/aspose-slides-for-java-21-11-release-notes/)에서 [ModernComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ModernComment) 클래스를 추가하여 최신 댓글 지원을 구현했습니다. [CommentCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/CommentCollection) 클래스에 [addModernComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) 및 [insertModernComment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) 메서드가 추가되었습니다.

다음 Java 코드는 PowerPoint 프레젠테이션의 슬라이드에 최신 댓글을 추가하는 방법을 보여줍니다: 

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **댓글 제거**

### **모든 댓글 및 저자 삭제**
다음 Java 코드는 프레젠테이션에서 모든 댓글과 저자를 제거하는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // 프레젠테이션에서 모든 댓글을 삭제합니다
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // 모든 저자를 삭제합니다
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **특정 댓글 삭제**
다음 Java 코드는 슬라이드에서 특정 댓글을 삭제하는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 댓글을 추가합니다...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // "comment 1" 텍스트를 포함하는 모든 댓글을 제거합니다
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **자주 묻는 질문**

**Aspose.Slides에서 최신 댓글에 '해결됨'과 같은 상태를 지원합니까?**

예. [Modern comments](https://reference.aspose.com/slides/ko/java/com.aspose.slides/moderncomment/)은 [setStatus](https://reference.aspose.com/slides/ko/java/com.aspose.slides/moderncomment/#setStatus-byte-) 메서드를 제공합니다; 이를 통해 [comment’s state](https://reference.aspose.com/slides/ko/java/com.aspose.slides/moderncommentstatus/) (예: 해결됨으로 표시) 를 지정할 수 있으며, 이 상태는 파일에 저장되고 PowerPoint에서 인식됩니다.

**스레드 형태 토론(답글 체인)이 지원되며, 중첩 제한이 있습니까?**

예. 각 댓글은 [parent comment](https://reference.aspose.com/slides/ko/java/com.aspose.slides/comment/#getParentComment--)을 참조할 수 있어 임의의 답글 체인을 만들 수 있습니다. API에서는 특정 중첩 깊이 제한을 명시하지 않습니다.

**슬라이드에서 댓글 마커의 위치는 어떤 좌표계에 정의되어 있습니까?**

위치는 슬라이드 좌표계의 부동 소수점 좌표로 저장됩니다. 이를 통해 원하는 정확한 위치에 댓글 마커를 배치할 수 있습니다.