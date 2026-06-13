---
title: Python에서 프레젠테이션 댓글 관리
linktitle: 프레젠테이션 댓글
type: docs
weight: 100
url: /ko/python-net/presentation-comments/
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
- 댓글 제거
- 댓글 삭제
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 프레젠테이션 댓글을 완벽하게 관리하세요: PowerPoint 파일에서 댓글을 빠르고 쉽게 추가, 읽기, 편집 및 삭제합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 프레젠테이션 댓글을 관리하는 방법을 설명합니다. 주요 댓글 관련 유형을 보여주고 슬라이드에 댓글을 추가하고, 기존 댓글에 접근하고, 답글을 작업하며, 모던 댓글을 사용하고, 프레젠테이션에서 댓글을 제거하는 방법을 시연합니다.

예제는 PowerPoint에서 일반적인 검토 및 협업 시나리오에 초점을 맞추며, 작성자에게 댓글을 할당하고, 댓글 내용 및 메타데이터를 읽고, 답글 체인을 구축하며, 모든 댓글을 삭제하거나 선택된 댓글만 삭제하는 방법을 다룹니다.

PowerPoint에서 댓글은 슬라이드 위의 메모 또는 주석으로 표시됩니다. 댓글을 클릭하면 해당 내용이나 메시지가 표시됩니다.

## **프레젠테이션에 댓글을 추가하는 이유**

프레젠테이션을 검토할 때 피드백을 제공하거나 동료와 커뮤니케이션하기 위해 댓글을 사용할 수 있습니다.

PowerPoint 프레젠테이션에서 댓글을 사용할 수 있도록 Aspose.Slides for Python via .NET은 다음을 제공합니다

* The [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) class, which contains the collections of authors (from the [CommentAuthorCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/commentauthorcollection/) property). The authors add comments to slides.
* The [CommentCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/commentcollection/) class, which contains the collection of comments for individual authors.
* The [Comment](https://reference.aspose.com/slides/ko/python-net/aspose.slides/comment/) class, which contains information on authors and their comments: who added the comment, the time the comment was added, the comment's position, etc.
* The [CommentAuthor](https://reference.aspose.com/slides/ko/python-net/aspose.slides/commentauthor/) class, which contains information on individual authors: the author's name, his initials, comments associated with the author's name, etc.

## **슬라이드에 댓글 추가**

This Python code shows you how to add a comment to a slide in a PowerPoint presentation:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Presentation 클래스를 인스턴스화합니다
with slides.Presentation() as presentation:
    # 빈 슬라이드를 추가합니다
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # 작성자를 추가합니다
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # 댓글 위치를 설정합니다
    point = draw.PointF(0.2, 0.2)

    # 작성자에 대한 슬라이드 1의 댓글을 추가합니다
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # 작성자에 대한 슬라이드 2의 댓글을 추가합니다
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # ISlide 1에 접근합니다
    slide = presentation.slides[0]

    # 인수로 null을 전달하면 모든 작성자의 댓글이 선택된 슬라이드에 가져와집니다
    comments = slide.get_slide_comments(author)

    # 슬라이드 1의 인덱스 0에 있는 댓글에 접근합니다
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # 인덱스 0에 있는 작성자의 댓글 컬렉션을 선택합니다
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```

## **슬라이드 댓글 접근**

This Python code shows you how to access an existing comment on a slide in a PowerPoint presentation:

```python
import aspose.slides as slides

# Presentation 클래스를 인스턴스화합니다
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```

## **댓글에 답글 달기**

부모 댓글은 댓글 및 답글 계층 구조에서 최상위 또는 원본 댓글을 의미합니다. [Comment](https://reference.aspose.com/slides/ko/python-net/aspose.slides/comment/) 클래스의 `parent_comment` 속성을 사용하여 부모 댓글을 설정하거나 가져올 수 있습니다.

This Python code shows you how to add comments and get replies to them:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # 댓글을 추가합니다
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # comment1에 대한 답글을 추가합니다
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # comment1에 대한 또 다른 답글을 추가합니다
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # 기존 답글에 대한 답글을 추가합니다
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # 콘솔에 댓글 계층 구조를 표시합니다
    slide = pres.slides[0]
    comments = slide.get_slide_comments(None)
    for i in range(comments.length):
        comment = comments[i]
        while comment.parent_comment is not None:
            print("\t")
            comment = comment.parent_comment

        print(comments[i].author.name + " : " + comments[i].text)
        print("\r\n")

    pres.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    # comment1과 그에 대한 모든 답글을 삭제합니다
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Attention" %}} 
* When the `remove` method (from the [Comment](https://reference.aspose.com/slides/ko/python-net/aspose.slides/comment/) class) is used to delete a comment, the replies to the comment also get deleted.
* If the `parent_comment` setting results in a circular reference, `PptxEditException` will be thrown.
{{% /alert %}}

## **모던 댓글 추가**

2021년에 Microsoft는 PowerPoint에 *모던 댓글*을 도입했습니다. 모던 댓글 기능은 PowerPoint에서의 협업을 크게 향상시킵니다. 모던 댓글을 통해 PowerPoint 사용자는 댓글을 해결하고, 댓글을 개체와 텍스트에 고정하며, 이전보다 훨씬 쉽게 상호작용할 수 있습니다.

우리는 [ModernComment](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncomment/) 클래스를 추가하여 모던 댓글 지원을 구현했습니다. `add_modern_comment` 및 `insert_modern_comment` 메서드가 [CommentCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/commentcollection/) 클래스에 추가되었습니다.

This Python code shows you how to add a modern comment to a slide in a PowerPoint presentation:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **댓글 제거**

### **모든 댓글 및 작성자 삭제**

This Python code shows you how to remove all comments and authors in a presentation:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # 프레젠테이션의 모든 댓글을 삭제합니다
    for author in presentation.comment_authors:
        author.comments.clear()

    # 모든 작성자를 삭제합니다
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **특정 댓글 삭제**

This Python code shows you how to delete specific comments on a slide:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # 댓글을 추가합니다...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # "comment 1" 텍스트를 포함하는 모든 댓글을 삭제합니다
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides에서 모던 댓글에 ‘해결됨’ 같은 상태를 지원하나요?**

예. [Modern comments](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncomment/)는 [status](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncomment/status/) 속성을 노출합니다; [comment’s state](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncommentstatus/)를 읽고 설정할 수 있으며(예: 해결됨으로 표시), 이 상태는 파일에 저장되고 PowerPoint에서 인식됩니다.

**스레드형 토론(답글 체인)이 지원되며 중첩 제한이 있나요?**

예. 각 댓글은 [parent comment](https://reference.aspose.com/slides/ko/python-net/aspose.slides/moderncomment/parent_comment/)를 참조할 수 있어 임의의 답글 체인을 만들 수 있습니다. API는 특정 중첩 깊이 제한을 선언하지 않습니다.

**슬라이드에서 댓글 마커 위치는 어떤 좌표계로 정의되나요?**

위치는 슬라이드 좌표계의 부동 소수점 좌표로 저장됩니다. 이를 통해 댓글 마커를 필요한 정확한 위치에 배치할 수 있습니다.