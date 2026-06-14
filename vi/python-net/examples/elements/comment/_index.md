---
title: Bình luận
type: docs
weight: 230
url: /vi/python-net/examples/elements/comment/
keywords:
- bình luận
- bình luận hiện đại
- thêm bình luận
- truy cập bình luận
- xóa bình luận
- trả lời bình luận
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý bình luận trên slide trong Python với Aspose.Slides: thêm, đọc, trả lời, chỉnh sửa, xóa và làm việc với các bình luận có chuỗi trả lời cho PowerPoint và OpenDocument."
---
Minh họa cách thêm, đọc, xóa và trả lời các bình luận hiện đại bằng **Aspose.Slides for Python via .NET**.

## **Thêm một bình luận hiện đại**

Tạo một bình luận do người dùng viết và lưu bản trình chiếu.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Thêm tác giả bình luận.
        author = presentation.comment_authors.add_author("User", "U1")

        # Thêm một bình luận hiện đại.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập một bình luận hiện đại**

Đọc một bình luận hiện đại từ bản trình chiếu hiện có.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # Truy cập bình luận hiện đại đầu tiên.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **Xóa một bình luận hiện đại**

Xóa một bình luận và lưu tệp đã cập nhật.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # Xóa bình luận.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Trả lời một bình luận hiện đại**

Thêm câu trả lời vào một bình luận hiện đại cha.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # Thêm bình luận cha.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # Thêm trả lời đầu tiên.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # Thêm trả lời thứ hai.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```