---
title: Pythonでのグループプレゼンテーションシェイプ
linktitle: シェイプ グループ
type: docs
weight: 40
url: /ja/python-net/group/
keywords:
- グループシェイプ
- シェイプグループ
- グループの追加
- 代替テキスト
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して、PowerPoint と OpenDocument デッキでシェイプをグループ化およびグループ解除する方法を学びます。高速でステップバイステップのガイドと無料コード付き。"
---

## **概要**

グループ化されたシェイプにより、複数の描画オブジェクトを単一のユニットとして扱うことができ、移動、サイズ変更、書式設定、変形をまとめて行うことができます。Aspose.Slides for Python を使用すると、[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) を作成し、その内部に子シェイプを追加・配置し、結果を PPTX に保存できます。本記事では、スライドにグループシェイプを追加する方法と、グループ内のシェイプから Alt Text などのアクセシビリティメタデータにアクセスする方法を示し、構造を整理し、より豊かで保守しやすいプレゼンテーションを実現します。

## **グループシェイプの追加**

Aspose.Slides はスライド上でのグループシェイプの操作をサポートします。この機能により、複数のシェイプを単一のオブジェクトとして扱うことで、よりリッチなプレゼンテーションを作成できます。新しいグループシェイプの追加、既存のものへのアクセス、子シェイプの配置、プロパティの読み取りや変更が可能です。スライドにグループシェイプを追加する手順は以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) を追加します。
4. 新しいグループシェイプにシェイプを追加します。
5. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下の例は、スライドにグループシェイプを追加する方法を示しています。
```py
import aspose.slides as slides

# Presentationクラスのインスタンスを作成します。
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

    # PPTXファイルをディスクに保存します。
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```


## **Alt Text プロパティへのアクセス**

Aspose.Slides を使用して、スライド上のグループシェイプに含まれるシェイプの Alt Text を読み取る方法を説明します。シェイプの Alt Text にアクセスする手順は以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、PPTX ファイルを表します。
2. インデックスでスライドへの参照を取得します。
3. スライドのシェイプコレクションにアクセスします。
4. [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) にアクセスします。
5. Alt Text プロパティを読み取ります。

以下の例は、グループシェイプに含まれるシェイプの Alt Text を取得します。
```py
import aspose.slides as slides

# PPTXファイルを開くためにPresentationクラスのインスタンスを作成します。
with slides.Presentation("group_shape.pptx") as presentation:
    # 最初のスライドを取得します。
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # グループシェイプにアクセスします。
            for child_shape in shape.shapes:
                # Alt Textプロパティにアクセスします。
                print(child_shape.alternative_text)
```


## **FAQ**

**ネストされたグルーピング（グループ内のグループ）はサポートされていますか？**

はい。[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) には [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/) プロパティがあり、階層構造のサポートを直接示します (グループは別のグループの子になることができます)。

**スライド上の他のオブジェクトに対して、グループの Z オーダーをどのように制御できますか？**

[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) の [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) プロパティを使用して、表示スタック内での位置を確認できます。

**移動/編集/グループ解除を防止できますか？**

はい。グループのロックセクションは [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/) により公開されており、オブジェクトに対する操作を制限できます。