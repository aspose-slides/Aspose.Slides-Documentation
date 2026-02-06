---
title: コメント
type: docs
weight: 230
url: /ja/python-net/examples/elements/comment/
keywords:
- コメント
- モダン コメント
- コメントを追加
- コメントにアクセス
- コメントを削除
- コメントに返信
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python で Aspose.Slides を使用してスライド コメントを管理します：追加、読み取り、返信、編集、削除、そして PowerPoint と OpenDocument 用のスレッド化されたコメントを操作します。"
---
**Aspose.Slides for Python via .NET** を使用して、モダン コメントの追加、読み取り、削除、および返信を実演します。

## **モダン コメントの追加**

ユーザーが作成したコメントを作成し、プレゼンテーションを保存します。

```py
def add_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # コメント作成者を追加します。
        author = presentation.comment_authors.add_author("User", "U1")

        # モダンコメントを追加します。
        author.comments.add_modern_comment(
            "This is a modern comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        presentation.save("modern_comment.pptx", slides.export.SaveFormat.PPTX)
```

## **モダン コメントへのアクセス**

既存のプレゼンテーションからモダン コメントを読み取ります。

```py
def access_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]

        # 最初のモダンコメントにアクセスします。
        comment = author.comments[0]

        print(f"Author: {author.name}, Comment: {comment.text}")
```

## **モダン コメントの削除**

コメントを削除し、更新されたファイルを保存します。

```py
def remove_modern_comment():
    with slides.Presentation("modern_comment.pptx") as presentation:
        author = presentation.comment_authors[0]
        comment = author.comments[0]

        # コメントを削除します。
        comment.remove()

        presentation.save("modern_comment_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **モダン コメントに返信**

親のモダン コメントに返信を追加します。

```py
def reply_to_modern_comment():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        author = presentation.comment_authors.add_author("User", "U1")

        # 親コメントを追加します。
        parent = author.comments.add_modern_comment(
            "Parent comment", slide, None, drawing.PointF(100, 100), datetime.date.today())

        # 最初の返信を追加します。
        reply1 = author.comments.add_modern_comment(
            "Reply 1", slide, None, drawing.PointF(110, 100), datetime.date.today())

        # 2番目の返信を追加します。
        reply2 = author.comments.add_modern_comment(
            "Reply 2", slide, None, drawing.PointF(120, 100), datetime.date.today())

        reply1.parent_comment = parent
        reply2.parent_comment = parent

        presentation.save("modern_comment_replies.pptx", slides.export.SaveFormat.PPTX)
```