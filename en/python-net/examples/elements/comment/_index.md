---
title: Comment
type: docs
weight: 230
url: /python-net/examples/elements/comment/
keywords:
- comment
- modern comment
- add comment
- access comment
- remove comment
- reply to comment
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Manage slide comments in Python with Aspose.Slides: add, read, reply, edit, delete, and work with threaded comments for PowerPoint and OpenDocument."
---

Demonstrates adding, reading, removing, and replying to modern comments using **Aspose.Slides for Python via .NET**.

## **Add a Modern Comment**

Create a comment authored by a user and save the presentation.

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Add a comment author.
        author = presentation.comment_authors.add_author("User", "U1")

        # Add a modern comment.
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Modern Comment**

Read a modern comment from an existing presentation.

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # Access the first modern comment.
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **Remove a Modern Comment**

Remove a comment and save the updated file.

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # Remove the comment.
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Reply to a Modern Comment**

Add replies to a parent modern comment.

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # Add parent comment.
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # Add first reply.
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # Add second reply.
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```
