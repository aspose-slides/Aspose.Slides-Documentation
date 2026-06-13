---
title: 댓글
type: docs
weight: 230
url: /ko/python-net/examples/elements/comment/
keywords:
- 댓글
- 현대 댓글
- 댓글 추가
- 댓글 접근
- 댓글 제거
- 댓글 회신
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 슬라이드 댓글을 관리합니다: 추가, 읽기, 회신, 편집, 삭제 및 PowerPoint와 OpenDocument용 스레드형 댓글 작업."
---
**Aspose.Slides for Python via .NET**를 사용하여 최신 댓글을 추가, 읽기, 제거 및 회신하는 방법을 보여줍니다.

## **현대 댓글 추가**

사용자가 작성한 댓글을 만들고 프레젠테이션을 저장합니다.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 댓글 작성자를 추가합니다.
        author = presentation.comment_authors.add_author("User", "U1")

        # 현대 댓글을 추가합니다.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **현대 댓글 접근**

기존 프레젠테이션에서 최신 댓글을 읽습니다.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # 첫 번째 현대 댓글에 접근합니다.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **현대 댓글 제거**

댓글을 제거하고 업데이트된 파일을 저장합니다.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # 댓글을 제거합니다.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **현대 댓글 회신**

상위 최신 댓글에 회신을 추가합니다.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # 상위 댓글을 추가합니다.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # 첫 번째 회신을 추가합니다.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # 두 번째 회신을 추가합니다.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```