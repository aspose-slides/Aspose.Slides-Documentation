---
title: Python 用 グループ プレゼンテーション シェイプ
linktitle: シェイプ グループ
type: docs
weight: 40
url: /ja/python-net/group/
keywords:
- グループ シェイプ
- シェイプ グループ
- グループ 追加
- 代替テキスト
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して PowerPoint および OpenDocument デッキでシェイプのグループ化とグループ解除を学びます — 速く、ステップバイステップのガイドと無料コード。"
---

## **概要**

シェイプをグループ化すると、複数の描画オブジェクトを単一のユニットとして扱えるようになり、まとめて移動、サイズ変更、書式設定、変形が可能になります。Aspose.Slides for Python を使用すれば、[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) を作成し、その中に子シェイプを追加・配置し、PPTX に保存できます。本稿では、スライドにグループシェイプを追加する方法と、グループ内シェイプから Alt Text などのアクセシビリティ メタデータにアクセスする方法を示し、構造がすっきりし、保守性が高まったプレゼンテーションを作成する手順を解説します。

## **グループ シェイプの追加**

Aspose.Slides はスライド上でのグループシェイプ操作をサポートしています。この機能を使うと、複数のシェイプを単一オブジェクトとして扱い、よりリッチなプレゼンテーションを構築できます。新しいグループシェイプの追加、既存のものへのアクセス、子シェイプの配置、プロパティの取得・変更が可能です。スライドにグループシェイプを追加する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. スライドに [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) を追加します。  
4. 新しいグループシェイプにシェイプを追加します。  
5. 変更したプレゼンテーションを PPTX ファイルとして保存します。

以下のサンプルは、スライドにグループシェイプを追加する方法を示しています。

```py
import aspose.slides as slides

# Presentation クラスをインスタンス化。
with slides.Presentation() as presentation:
    # 最初のスライドを取得。
    slide = presentation.slides[0]

    # スライドにグループシェイプを追加。
    group_shape = slide.shapes.add_group_shape()

    # グループシェイプ内にシェイプを追加。
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # PPTX ファイルを書き出し。
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Alt Text プロパティへのアクセス**

このセクションでは、Aspose.Slides を使用してスライド上のグループシェイプに含まれるシェイプの Alt Text を読み取る方法を説明します。Alt Text にアクセスする手順は次のとおりです。

1. PPTX ファイルを表すために [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスをインスタンス化します。  
2. インデックスでスライドへの参照を取得します。  
3. スライドの shapes コレクションにアクセスします。  
4. [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) を取得します。  
5. Alt Text プロパティを読み取ります。

以下の例は、グループシェイプ内のシェイプから Alt Text を取得する方法を示しています。

```py
import aspose.slides as slides

# PPTX ファイルを開くために Presentation クラスをインスタンス化。
with slides.Presentation("group_shape.pptx") as presentation:
    # 最初のスライドを取得。
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # グループシェイプにアクセス。
            for child_shape in shape.shapes:
                # Alt Text プロパティにアクセス。
                print(child_shape.alternative_text)
```

## **FAQ**

**入れ子のグループ化（グループ内にグループ）はサポートされていますか？**

はい。[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) には [parent_group](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/parent_group/) プロパティがあり、階層構造のサポート（あるグループが別のグループの子になる）を直接示します。

**スライド上の他のオブジェクトに対するグループの Z オーダーをどのように制御できますか？**

[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) の [z_order_position](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/z_order_position/) プロパティを使用して、表示スタック内での位置を取得または変更できます。

**移動/編集/グループ解除を防止できますか？**

はい。グループのロック設定は [group_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/group_shape_lock/) で公開されており、オブジェクトに対する操作を制限できます。