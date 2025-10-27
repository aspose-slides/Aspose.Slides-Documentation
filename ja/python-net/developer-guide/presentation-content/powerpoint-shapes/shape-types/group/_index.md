---
title: Group Presentation Shapes with Python
linktitle: Shape Group
type: docs
weight: 40
url: /ja/python-net/group/
keywords:
- group shape
- shape group
- add group
- alternative text
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Learn to group and ungroup shapes in PowerPoint and OpenDocument decks using Aspose.Slides for Python—fast, step-by-step guide with free code."
---

## **概要**

シェイプをグループ化すると、複数の描画オブジェクトを単一のユニットとして扱えるようになり、まとめて移動、サイズ変更、書式設定、変形が可能です。Aspose.Slides for Python を使用すれば、[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) を作成し、その内部に子シェイプを追加・配置し、PPTX に保存できます。本稿では、スライドにグループシェイプを追加する方法と、グループ内シェイプから Alt Text などのアクセシビリティメタデータにアクセスする方法を示し、構造が整理された、より保守性の高いプレゼンテーションの作成を支援します。

## **グループシェイプの追加**

Aspose.Slides はスライド上のグループシェイプの操作をサポートしています。この機能により、複数のシェイプを単一オブジェクトとして扱い、よりリッチなプレゼンテーションを構築できます。新しいグループシェイプの追加、既存シェイプへのアクセス、子シェイプの配置、プロパティの取得・変更が可能です。スライドにグループシェイプを追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) を追加します。
4. 新しいグループシェイプにシェイプを追加します。
5. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下のサンプルは、スライドにグループシェイプを追加する方法を示しています。

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add a group shape to the slide.
    group_shape = slide.shapes.add_group_shape()

    # Add shapes inside the group shape.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Write the PPTX file to disk.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Alt テキスト プロパティへのアクセス**

このセクションでは、Aspose.Slides を使用してスライド上のグループシェイプ内に含まれるシェイプの Alt Text を取得する方法を説明します。Alt Text にアクセスする手順は次のとおりです。

1. PPTX ファイルを表す [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドの shapes コレクションにアクセスします。
4. [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) を取得します。
5. Alt Text プロパティを読み取ります。

以下のサンプルは、グループシェイプ内に含まれるシェイプの Alt Text を取得する例です。

```py
import aspose.slides as slides

# Instantiate the Presentation class to open the PPTX file.
with slides.Presentation("group_shape.pptx") as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Access the group shape.
            for child_shape in shape.shapes:
                # Access the Alt Text property.
                print(child_shape.alternative_text)
```

## **FAQ**

**入れ子のグルーピング（グループ内にグループ）はサポートされていますか？**

はい。[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) は [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/) プロパティを持ち、階層構造を直接示します（グループは別のグループの子になることができます）。

**スライド上の他オブジェクトに対するグループの Z オーダーをどう制御しますか？**

[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) の [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) プロパティを使用して、表示スタック内での位置を確認・変更できます。

**移動／編集／グループ解除を防止できますか？**

はい。グループのロック情報は [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/) で公開されており、オブジェクトに対する操作を制限できます。