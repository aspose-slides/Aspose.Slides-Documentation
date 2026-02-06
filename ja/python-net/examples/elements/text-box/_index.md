---
title: テキストボックス
type: docs
weight: 40
url: /ja/python-net/examples/elements/text-box/
keywords:
- テキストボックス
- テキストボックスを追加
- テキストボックスにアクセス
- テキストボックスを削除
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python でテキストボックスを作成および書式設定します。フォント、配置、折り返し、オートフィット、リンクを設定し、PowerPoint および OpenDocument 用のスライドを洗練させます。"
---
Aspose.Slidesでは、**テキストボックス**は `AutoShape` で表されます。ほぼすべての図形にテキストを含めることができますが、典型的なテキストボックスは塗りつぶしや枠線がなく、テキストのみが表示されます。

このガイドでは、テキストボックスをプログラムで追加、アクセス、削除する方法を説明します。

## **テキストボックスの追加**

テキストボックスは、塗りつぶしや枠線がなく、いくつかの書式設定されたテキストを持つ単なる `AutoShape` です。作成方法は次のとおりです：

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 矩形シェイプを作成します（デフォルトでは枠線付きで塗りつぶされ、テキストはありません）。
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # 塗りつぶしと枠線を削除して、典型的なテキストボックスのように見せます。
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # テキストの書式設定を行います。
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # 実際のテキスト コンテンツを割り当てます。
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **注:** 非空の `TextFrame` を含む `AutoShape` はすべてテキストボックスとして機能します。

## **コンテンツでテキストボックスにアクセス**

特定のキーワード（例: "Slide"）を含むすべてのテキストボックスを見つけるには、図形を反復処理し、そのテキストを確認します：

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # AutoShape のみが編集可能なテキストを含めることができます。
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # 一致するテキストボックスで何か処理を行います。
                    pass
```

## **コンテンツでテキストボックスを削除**

この例は、特定のキーワードを含む最初のスライド上のすべてのテキストボックスを検索して削除します：

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # 「Slide」という単語を含む AutoShape で削除すべきシェイプを検索します。
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # スライドから一致するシェイプをすべて削除します。
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **ヒント:** イテレーション中に変更する際は、コレクションの変更エラーを防ぐために常にシェイプコレクションのコピーを作成してください。