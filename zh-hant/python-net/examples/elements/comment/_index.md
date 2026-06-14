---
title: 評論
type: docs
weight: 230
url: /zh-hant/python-net/examples/elements/comment/
keywords:
- 評論
- 現代評論
- 新增評論
- 取得評論
- 移除評論
- 回覆評論
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中管理投影片評論：新增、讀取、回覆、編輯、刪除，並處理 PowerPoint 與 OpenDocument 的串接評論。"
---
示範如何使用 **Aspose.Slides for Python via .NET** 新增、讀取、移除以及回覆現代評論。

## **新增現代評論**

建立由使用者撰寫的評論，並儲存簡報。

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 新增評論作者。
        author = presentation.comment_authors.add_author("User", "U1")

        # 新增現代評論。
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **取得現代評論**

從現有簡報中讀取現代評論。

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # 取得第一個現代評論。
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **移除現代評論**

移除評論並儲存已更新的檔案。

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # 移除評論。
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **回覆現代評論**

為父層現代評論新增回覆。

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # 新增父級評論。
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # 新增第一則回覆。
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # 新增第二則回覆。
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```