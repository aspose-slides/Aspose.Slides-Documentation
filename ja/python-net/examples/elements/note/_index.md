---
title: ノート
type: docs
weight: 240
url: /ja/python-net/examples/elements/note/
keywords:
- ノート
- ノート スライドを追加
- ノート スライドにアクセス
- ノート スライドを削除
- ノート テキストを更新
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python と Aspose.Slides を使用してスピーカー ノートを追加、読み取り、編集、エクスポートします。テキストの書式設定、スライドごとのノート管理、PowerPoint および OpenDocument での表示制御が可能です。"
---
**Aspose.Slides for Python via .NET** を使用して、ノート スライドの追加、読み取り、削除、更新方法を示します。

## **ノート スライドの追加**

ノート スライドを作成し、テキストを割り当てます。

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **ノート スライドにアクセス**

既存のノート スライドからテキストを読み取ります。

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **ノート スライドの削除**

スライドに関連付けられたノート スライドを削除します。

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # ノート スライドを削除します。
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ノート テキストの更新**

ノート スライドのテキストを変更します。

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # ノート テキストを更新します。
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```