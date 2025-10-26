---
title: Pythonでのグループプレゼンテーションシェイプ
linktitle: シェイプ グループ
type: docs
weight: 40
url: /ja/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/group/
keywords:
- グループシェイプ
- シェイプ グループ
- グループの追加
- 代替テキスト
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して PowerPoint および OpenDocument デッキでシェイプをグループ化およびグループ解除する方法を学びます—高速でステップバイステップのガイドと無料コードを提供します。"
---

## **概要**

シェイプをグループ化すると、複数の描画オブジェクトを1つのユニットとして扱えるようになり、まとめて移動、サイズ変更、書式設定、変形が可能です。Aspose.Slides for Python を使用すると、[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) を作成し、その内部に子シェイプを追加・配置し、結果を PPTX に保存できます。本記事では、スライドにグループシェイプを追加する方法と、グループ内のシェイプから Alt Text などのアクセシビリティメタデータにアクセスする方法を示し、構造を整理し、よりリッチで保守性の高いプレゼンテーションを実現します。

## **グループシェイプの追加**

Aspose.Slides はスライド上でのグループシェイプの操作をサポートしています。この機能により、複数のシェイプを1つのオブジェクトとして扱うことで、よりリッチなプレゼンテーションを構築できます。新しいグループシェイプの追加、既存のグループシェイプへのアクセス、子シェイプの配置、プロパティの読み書きが可能です。スライドにグループシェイプを追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) を追加します。
4. 新しいグループシェイプにシェイプを追加します。
5. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例は、スライドにグループシェイプを追加する方法を示しています。

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

## **Alt Text プロパティへのアクセス**

このセクションでは、Aspose.Slides を使用してスライド上のグループシェイプに含まれるシェイプの Alt Text を読み取る方法を説明します。シェイプの Alt Text にアクセスする手順は次のとおりです。

1. PPTX ファイルを表すために [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドのシェイプコレクションにアクセスします。
4. [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) にアクセスします。
5. Alt Text プロパティを読み取ります。

以下の例は、グループシェイプ内に含まれるシェイプの Alt Text を取得する方法を示しています。

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

**ネストされたグルーピング（グループ内のグループ）はサポートされていますか？**

はい。[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) には [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/) プロパティがあり、階層構造のサポート（あるグループが別のグループの子になること）が直接示されています。

**スライド上の他のオブジェクトに対するグループの Z オーダーをどのように制御しますか？**

[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) の [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) プロパティを使用して、表示スタック内での位置を確認または変更できます。

**移動/編集/グループ解除を防止できますか？**

はい。グループのロックセクションは [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/) を介して公開されており、オブジェクトに対する操作を制限できます。