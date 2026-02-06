---
title: レイアウト スライド
type: docs
weight: 20
url: /ja/python-net/examples/elements/layout-slide/
keywords:
- レイアウト スライド
- レイアウト スライドの追加
- レイアウト スライドへのアクセス
- レイアウト スライドの削除
- 未使用のレイアウト スライド
- レイアウト スライドのクローン作成
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python を使用して Aspose.Slides でレイアウト スライドを管理します：プレゼンテーション（PPT、PPTX、ODP）のプレースホルダーやテーマを作成、適用、クローン作成、名前変更、カスタマイズします。"
---
この記事では、Aspose.Slides for Python via .NETで**Layout Slides**を操作する方法を示します。レイアウト スライドは、通常のスライドが継承するデザインと書式設定を定義します。レイアウト スライドを追加、アクセス、クローン、削除でき、未使用のものをクリーンアップしてプレゼンテーションのサイズを削減することもできます。

## **レイアウト スライドの追加**

再利用可能な書式設定を定義するために、カスタム レイアウト スライドを作成できます。

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # 指定されたタイプと名前でレイアウト スライドを作成します。
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** レイアウト スライドは個々のスライドのテンプレートとして機能します。共通の要素を一度定義すれば、複数のスライドで再利用できます。

> 💡 **Tip 2:** レイアウト スライドに図形やテキストを追加すると、そのレイアウトに基づくすべてのスライドがこの共有コンテンツを自動的に表示します。以下のスクリーンショットは、同じレイアウト スライドからテキスト ボックスを継承した 2 つのスライドを示しています。

![レイアウト コンテンツを継承するスライド](layout-slide-result.png)


## **レイアウト スライドへのアクセス**

レイアウト スライドはインデックスまたはレイアウト タイプ（例: `Blank`, `Title`, `SectionHeader` など）でアクセスできます。

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # インデックスでアクセスします。
        first_layout_slide = presentation.layout_slides[0]

        # レイアウト タイプでアクセスします。
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **レイアウト スライドの削除**

不要になった特定のレイアウト スライドを削除できます。

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # タイプでレイアウト スライドを取得し、削除します。
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **未使用のレイアウト スライドの削除**

プレゼンテーションのサイズを縮小するために、通常のスライドで使用されていないレイアウト スライドを削除したい場合があります。

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # スライドで参照されていないすべてのレイアウト スライドを自動的に削除します。
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **レイアウト スライドのクローン作成**

`AddClone` メソッドを使用してレイアウト スライドを複製できます。

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # タイプで既存のレイアウト スライドを取得します。
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # レイアウト スライドをレイアウト スライド コレクションの末尾にクローン作成します。
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **概要:** レイアウト スライドは、スライド全体で一貫した書式設定を管理するための強力なツールです。Aspose.Slides を使用すると、レイアウト スライドの作成、管理、最適化を完全にコントロールできます。