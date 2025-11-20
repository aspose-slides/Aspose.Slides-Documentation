---
title: Python を使用したプレゼンテーションシェイプのグループ化
linktitle: シェイプ グループ
type: docs
weight: 40
url: /ja/python-net/group/
keywords:
- グループシェイプ
- シェイプ グループ
- グループの追加
- 代替テキスト
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して PowerPoint と OpenDocument デッキでシェイプをグループ化およびグループ解除する方法を学びます—高速でステップバイステップのガイドと無料コード付き。"
---

## **概要**

シェイプのグループ化により、複数の描画オブジェクトを単一のユニットとして扱うことができ、移動、サイズ変更、書式設定、変形をまとめて行えます。Aspose.Slides for Python を使用すると、[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) を作成し、その内部に子シェイプを追加・配置し、結果を PPTX に保存できます。本記事では、スライドにグループ シェイプを追加する方法と、グループ内のシェイプから Alt Text などのアクセシビリティ メタデータにアクセスする方法を示し、構造を整理し、より保守性の高いプレゼンテーションを実現する方法を解説します。

## **グループ シェイプの追加**

Aspose.Slides はスライド上でのグループ シェイプの操作をサポートしています。この機能を利用すると、複数のシェイプを単一オブジェクトとして扱い、プレゼンテーションをよりリッチに構築できます。新しいグループ シェイプの追加、既存シェイプへのアクセス、子シェイプの配置、プロパティの取得や変更が可能です。スライドにグループ シェイプを追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) を追加します。
4. 新しいグループ シェイプにシェイプを追加します。
5. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

以下の例は、スライドにグループ シェイプを追加する方法を示しています。
```py
import aspose.slides as slides

# Presentation クラスをインスタンス化します。
with slides.Presentation() as presentation:
    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    # スライドにグループ シェイプを追加します。
    group_shape = slide.shapes.add_group_shape()

    # グループ シェイプ内にシェイプを追加します。
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # PPTX ファイルをディスクに保存します。
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```


## **Alt Text プロパティへのアクセス**

このセクションでは、Aspose.Slides を使用してスライド上のグループ シェイプに含まれるシェイプの Alt Text を取得する方法を説明します。Alt Text にアクセスする手順は次のとおりです。

1. PPTX ファイルを表すために [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドのシェイプ コレクションにアクセスします。
4. [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) にアクセスします。
5. Alt Text プロパティを読み取ります。

以下の例は、グループ シェイプに含まれるシェイプの Alt Text を取得する方法を示しています。
```py
import aspose.slides as slides

# PPTX ファイルを開くために Presentation クラスをインスタンス化します。
with slides.Presentation("group_shape.pptx") as presentation:
    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # グループ シェイプにアクセスします。
            for child_shape in shape.shapes:
                # Alt Text プロパティにアクセスします。
                print(child_shape.alternative_text)
```


## **FAQ**

**ネストされたグループ化（グループ内のグループ）はサポートされていますか？**

はい。[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) には [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/) プロパティがあり、階層構造のサポート（グループが別のグループの子になること）を直接示します。

**スライド上の他のオブジェクトに対するグループの Z オーダーはどのように制御しますか？**

[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) の [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) プロパティを使用して、表示スタック内の位置を確認または変更できます。

**移動・編集・グループ解除を防止できますか？**

はい。グループのロック セクションは [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/) を通じて公開されており、オブジェクトに対する操作を制限できます。