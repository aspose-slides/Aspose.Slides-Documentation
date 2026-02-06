---
title: スライド
type: docs
weight: 10
url: /ja/python-net/examples/elements/slide/
keywords:
- スライド
- スライドの追加
- スライドへのアクセス
- スライドインデックス
- スライドのクローン作成
- スライドの順序変更
- スライドの削除
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用した Python でのスライド管理: 作成、クローン作成、順序変更、非表示、背景とサイズの設定、トランジションの適用、PowerPoint および OpenDocument へのエクスポート。"
---
この記事では、**Aspose.Slides for Python via .NET** を使用してスライドを操作する方法を示す一連の例を提供します。`Presentation` クラスを使用して、スライドの追加、取得、クローン作成、順序変更、削除方法を学びます。

以下の各例は、簡単な説明と Python のコードスニペットで構成されています。

## **スライドの追加**

新しいスライドを追加するには、まずレイアウトを選択する必要があります。この例では `Blank` レイアウトを使用し、プレゼンテーションに空のスライドを追加します。

```py
def add_slide():
    with slides.Presentation() as presentation:
        # 各スライドはレイアウトに基づいており、そのレイアウトはマスタースライドに基づいています。
        # Blankレイアウトを使用して新しいスライドを作成します。
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # 選択したレイアウトを使用して新しい空のスライドを追加します。
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **ヒント:** 各スライドレイアウトはマスタースライドから派生しており、全体のデザインとプレースホルダー構造を定義します。下の画像は、PowerPoint でマスタースライドとそれに関連するレイアウトがどのように構成されているかを示しています。

![Master and Layout Relationship](master-layout-slide.png)

## **インデックスでスライドにアクセス**

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # インデックスでスライドにアクセスします。
        first_slide = presentation.slides[0]
```

## **スライドのクローン作成**

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # スライドをクローンします。プレゼンテーションの最後に追加されます。
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドの順序変更**

スライドの順序は、スライドを新しいインデックスに移動させることで変更できます。この例では、スライドを最初の位置に移動します。

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # スライドを最初の位置に移動します（他のスライドは下にシフト）。
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドの削除**

スライドを削除するには、対象のスライドを参照して `remove` を呼び出すだけです。この例では最初のスライドを削除します。

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # スライドを削除します。
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```