---
title: .NET에서 프레젠테이션 댓글 관리
linktitle: 프레젠테이션 댓글
type: docs
weight: 100
url: /ko/net/presentation-comments/
keywords:
- 댓글
- 현대식 댓글
- PowerPoint 댓글
- 프레젠테이션 댓글
- 슬라이드 댓글
- 댓글 추가
- 댓글 접근
- 댓글 편집
- 댓글 답변
- 댓글 제거
- 댓글 삭제
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용해 프레젠테이션 댓글을 마스터하세요: PowerPoint 파일에서 댓글을 빠르고 쉽게 추가, 읽기, 편집 및 삭제합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 프레젠테이션 댓글을 관리하는 방법을 설명합니다. 주요 댓글 관련 형식을 보여 주고, 슬라이드에 댓글을 추가하고, 기존 댓글에 접근하며, 답글을 처리하고, 최신 댓글을 사용하고, 프레젠테이션에서 댓글을 제거하는 방법을 시연합니다.

예제에서는 PowerPoint에서 일반적인 검토 및 협업 시나리오, 예를 들어 저자에게 댓글을 할당하고, 댓글 내용 및 메타데이터를 읽고, 답글 체인을 구축하고, 모든 댓글을 정리하거나 선택한 댓글을 삭제하는 방법에 중점을 둡니다.

PowerPoint에서 댓글은 슬라이드의 메모 또는 주석 형태로 표시됩니다. 댓글을 클릭하면 내용이나 메시지가 표시됩니다.

## **프레젠테이션에 댓글을 추가하는 이유는?**

프레젠테이션을 검토할 때 피드백을 제공하거나 동료와 소통하기 위해 댓글을 사용하고 싶을 수 있습니다.

PowerPoint 프레젠테이션에서 댓글을 사용할 수 있도록 Aspose.Slides for .NET은 다음을 제공합니다.

* The [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스는 저자 컬렉션([CommentAuthorCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/icommentauthorcollection/properties/index) 속성)을 포함합니다. 저자는 슬라이드에 댓글을 추가합니다. 
* The [ICommentCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/icommentcollection) 인터페이스는 개별 저자별 댓글 컬렉션을 포함합니다. 
* The [IComment](https://reference.aspose.com/slides/ko/net/aspose.slides/icomment) 클래스는 저자 및 댓글에 대한 정보를 포함합니다: 누가 댓글을 추가했는지, 댓글이 추가된 시각, 댓글 위치 등. 
* The [CommentAuthor](https://reference.aspose.com/slides/ko/net/aspose.slides/commentauthor) 클래스는 개별 저자에 대한 정보를 포함합니다: 저자 이름, 이니셜, 저자 이름과 연결된 댓글 등. 

## **슬라이드 댓글 추가**
이 C# 코드에서는 PowerPoint 프레젠테이션의 슬라이드에 댓글을 추가하는 방법을 보여 줍니다:

```c#
// Presentation 클래스를 인스턴스화합니다
using (Presentation presentation = new Presentation())
{
    // 빈 슬라이드를 추가합니다
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // 저자를 추가합니다
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // 댓글 위치를 설정합니다
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // 슬라이드 1에 저자를 위한 슬라이드 댓글을 추가합니다
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // 슬라이드 2에 저자를 위한 슬라이드 댓글을 추가합니다
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // ISlide 1에 접근합니다
    ISlide slide = presentation.Slides[0];

    // null을 인수로 전달하면 모든 저자의 댓글이 선택된 슬라이드로 가져와집니다
    IComment[] Comments = slide.GetSlideComments(author);

    // 슬라이드 1의 인덱스 0에 있는 댓글에 접근합니다
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // 인덱스 0에 있는 저자의 댓글 컬렉션을 선택합니다
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **슬라이드 댓글 접근**
이 C# 코드에서는 PowerPoint 프레젠테이션의 슬라이드에 있는 기존 댓글에 접근하는 방법을 보여 줍니다:

```c#
// Presentation 클래스를 인스턴스화합니다
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " has comment: " + comment.Text + " with Author: " + comment.Author.Name + " posted on time :" + comment.CreatedTime + "\n");
        }
    }
}
```

## **댓글에 답변 달기**
상위 댓글은 댓글이나 답변 계층 구조에서 최상위 또는 원본 댓글을 의미합니다. [ParentComment](https://reference.aspose.com/slides/ko/net/aspose.slides/icomment/properties/parentcomment) 속성([IComment](https://reference.aspose.com/slides/ko/net/aspose.slides/icomment) 인터페이스에서)을 사용하여 상위 댓글을 설정하거나 가져올 수 있습니다. 

이 C# 코드에서는 댓글을 추가하고 해당 댓글에 대한 답변을 가져오는 방법을 보여 줍니다:

```c#
using (Presentation pres = new Presentation())
{
    // 댓글을 추가합니다
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // comment1에 대한 답글을 추가합니다
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // comment1에 대한 또 다른 답글을 추가합니다
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // 기존 답글에 대한 답글을 추가합니다
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // 콘솔에 댓글 계층 구조를 표시합니다
    ISlide slide = pres.Slides[0];
    var comments = slide.GetSlideComments(null);
    for (int i = 0; i < comments.Length; i++)
    {
        IComment comment = comments[i];
        while (comment.ParentComment != null)
        {
            Console.Write("\t");
            comment = comment.ParentComment;
        }

        Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        Console.WriteLine();
    }

    pres.Save("parent_comment.pptx",SaveFormat.Pptx);

    // comment1 및 그에 대한 모든 답글을 제거합니다
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Attention" %}} 

* [Remove](https://reference.aspose.com/slides/ko/net/aspose.slides/icomment/methods/remove) 메서드([IComment](https://reference.aspose.com/slides/ko/net/aspose.slides/icomment) 인터페이스에서)를 사용하여 댓글을 삭제하면 해당 댓글에 대한 답변도 삭제됩니다. 
* [ParentComment](https://reference.aspose.com/slides/ko/net/aspose.slides/icomment/properties/parentcomment) 설정이 순환 참조를 일으키면 [PptxEditException](https://reference.aspose.com/slides/ko/net/aspose.slides/pptxeditexception)이 발생합니다. 

{{% /alert %}}

## **현대식 댓글 추가**

2021년에 Microsoft는 PowerPoint에 *현대식 댓글*을 도입했습니다. 현대식 댓글 기능은 PowerPoint 협업을 크게 개선합니다. 현대식 댓글을 통해 사용자는 댓글을 해결하고, 객체와 텍스트에 댓글을 고정하며, 이전보다 훨씬 쉽게 상호작용할 수 있습니다. 

[Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/ko/net/aspose-slides-for-net-21-11-release-notes/)에서는 [ModernComment](https://reference.aspose.com/slides/ko/net/aspose.slides/moderncomment) 클래스를 추가하여 현대식 댓글 지원을 구현했습니다. [AddModernComment](https://reference.aspose.com/slides/ko/net/aspose.slides/commentcollection/methods/addmoderncomment) 및 [InsertModernComment](https://reference.aspose.com/slides/ko/net/aspose.slides/commentcollection/methods/insertmoderncomment) 메서드가 [CommentCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/commentcollection) 클래스에 추가되었습니다. 

이 C# 코드에서는 PowerPoint 프레젠테이션의 슬라이드에 현대식 댓글을 추가하는 방법을 보여 줍니다: 

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **댓글 제거**

### **모든 댓글 및 저자 삭제**

이 C# 코드는 프레젠테이션에서 모든 댓글과 저자를 제거하는 방법을 보여 줍니다:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // 프레젠테이션의 모든 댓글을 삭제합니다
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // 모든 저자를 삭제합니다
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **특정 댓글 삭제**

이 C# 코드는 슬라이드에서 특정 댓글을 삭제하는 방법을 보여 줍니다:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // 댓글을 추가합니다...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // "comment 1" 텍스트를 포함하는 모든 댓글을 제거합니다
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comment 1")
            {
                toRemove.Add(comment);
            }
        }
        
        foreach (IComment comment in toRemove)
        {
            commentAuthor.Comments.Remove(comment);
        }
    }
    
    presentation.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Aspose.Slides가 현대식 댓글에 대해 '해결됨'과 같은 상태를 지원합니까?**

예. [Modern comments](https://reference.aspose.com/slides/ko/net/aspose.slides/moderncomment/)는 [Status](https://reference.aspose.com/slides/ko/net/aspose.slides/moderncomment/status/) 속성을 제공하므로 댓글의 상태(예: 해결됨으로 표시)를 읽고 설정할 수 있으며, 이 상태는 파일에 저장되고 PowerPoint에서 인식됩니다.

**스레드형 토론(답변 체인)이 지원되며 중첩 제한이 있나요?**

예. 각 댓글은 자신의 [parent comment](https://reference.aspose.com/slides/ko/net/aspose.slides/comment/parentcomment/)을 참조할 수 있어 원하는 만큼 깊은 답변 체인을 만들 수 있습니다. API에서는 특정 중첩 깊이 제한을 명시하지 않습니다.

**슬라이드에서 댓글 마커 위치는 어떤 좌표계로 정의되나요?**

위치는 슬라이드 좌표계의 부동 소수점 좌표로 저장됩니다. 이를 통해 댓글 마커를 원하는 정확한 위치에 배치할 수 있습니다.