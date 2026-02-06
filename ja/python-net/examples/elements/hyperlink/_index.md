---
title: ハイパーリンク
type: docs
weight: 130
url: /ja/python-net/examples/elements/hyperlink/
keywords:
- ハイパーリンク
- ハイパーリンクの追加
- ハイパーリンクへのアクセス
- ハイパーリンクの削除
- ハイパーリンクの更新
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python でハイパーリンクを追加、編集、削除します：テキスト、図形、スライド、URL、メールへのリンク；PPT、PPTX、ODP のターゲットとアクションを設定します。"
---
**Aspose.Slides for Python via .NET** を使用して、図形上のハイパーリンクの追加、取得、削除、更新を実演します。

## **ハイパーリンクの追加**

外部サイトへリンクするハイパーリンクを持つ矩形シェイプを作成します。

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **ハイパーリンクの取得**

シェイプのテキスト部分からハイパーリンク情報を読み取ります。

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **ハイパーリンクの削除**

シェイプのテキストからハイパーリンクをクリアします。

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ハイパーリンクの更新**

既存のハイパーリンクの対象先を変更します。`HyperlinkManager` を使用して、すでにハイパーリンクが含まれているテキストを変更し、PowerPoint がハイパーリンクを安全に更新する方法を模倣します。

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # 既存のテキスト内のハイパーリンクを変更する場合は、
        # HyperlinkManager を使用し、プロパティを直接設定しないでください。
        # これは PowerPoint がハイパーリンクを安全に更新する方法を模倣しています。
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```