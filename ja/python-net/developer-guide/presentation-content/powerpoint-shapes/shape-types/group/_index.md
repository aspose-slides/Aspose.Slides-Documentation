---
title: Pythonでのグループプレゼンテーションシェイプ
linktitle: シェイプ グループ
type: docs
weight: 40
url: /ja/python-net/group/
keywords:
- グループ シェイプ
- シェイプ グループ
- グループを追加
- 代替テキスト
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して、PowerPoint および OpenDocument デッキでシェイプをグループ化およびグループ解除する方法を学びます—高速でステップバイステップのガイド、無料コード付き。"
---

## **概要**

シェイプをグループ化すると、複数の描画オブジェクトを単一のユニットとして扱えるようになり、同時に移動、サイズ変更、書式設定、変形が可能です。Aspose.Slides for Python を使用すると、[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) を作成し、その内部に子シェイプを追加・配置し、結果を PPTX として保存できます。本記事では、スライド上にグループシェイプを追加する方法と、グループ内のシェイプから Alt Text などのアクセシビリティ メタデータにアクセスする方法を示し、構造を整理し、よりリッチで保守しやすいプレゼンテーションを実現します。

## **グループシェイプの追加**

Aspose.Slides はスライド上でのグループシェイプの操作をサポートします。この機能により、複数のシェイプを単一オブジェクトとして扱い、よりリッチなプレゼンテーションを作成できます。新しいグループシェイプの追加、既存の取得、子シェイプの配置、プロパティの読み取りや変更が可能です。スライドにグループシェプを追加する手順は次のとおりです：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) を追加します。
4. 新しいグループシェイプにシェイプを追加します。
5. 変更したプレゼンテーションを PPTX ファイルとして保存します。

```py
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # スライドにグループシェイプを追加します。
    group_shape = slide.shapes.add_group_shape()

    # グループシェイプ内にシェイプを追加します。
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # PPTX ファイルをディスクに書き込みます。
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Alt Text プロパティへのアクセス**

このセクションでは、Aspose.Slides を使用してスライド上のグループシェイプ内に含まれるシェイプの Alt Text を取得する方法を説明します。シェイプの Alt Text にアクセスする手順は次のとおりです：

1. PPTX ファイルを表すために [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドのシェイプコレクションにアクセスします。
4. [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) にアクセスします。
5. Alt Text プロパティを読み取ります。

```py
import aspose.slides as slides

# PPTX ファイルを開くために Presentation クラスのインスタンスを作成します。
with slides.Presentation("group_shape.pptx") as presentation:
    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # グループシェイプにアクセスします。
            for child_shape in shape.shapes:
                # Alt Text プロパティにアクセスします。
                print(child_shape.alternative_text)
```

## **FAQ**

**ネストされたグルーピング（グループ内のグループ）はサポートされていますか？**

はい。[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) には [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/) プロパティがあり、階層構造のサポート（グループが別のグループの子になること）が直接示されています。

**スライド上の他のオブジェクトに対するグループの Z オーダーをどう制御しますか？**

[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) の [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) プロパティを使用して、表示スタック内での位置を確認または変更します。

**移動/編集/グループ解除を防止できますか？**

はい。グループのロックセクションは [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/) で公開されており、オブジェクトに対する操作を制限できます。