---
title: 评论
type: docs
weight: 230
url: /zh/python-net/examples/elements/comment/
keywords:
- 评论
- 现代评论
- 添加评论
- 访问评论
- 删除评论
- 回复评论
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中管理幻灯片评论：添加、读取、回复、编辑、删除，并在 PowerPoint 和 OpenDocument 中使用线程评论。"
---
演示如何使用 **Aspose.Slides for Python via .NET** 添加、读取、删除和回复现代评论。

## **添加现代评论**

创建由用户撰写的评论并保存演示文稿。

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 添加评论作者。
        author = presentation.comment_authors.add_author("User", "U1")

        # 添加现代评论。
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **访问现代评论**

从现有演示文稿中读取现代评论。

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # 访问第一个现代评论。
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **删除现代评论**

删除评论并保存更新后的文件。

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # 删除评论。
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **回复现代评论**

向父级现代评论添加回复。

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # 添加父评论。
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # 添加第一条回复。
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # 添加第二条回复。
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```