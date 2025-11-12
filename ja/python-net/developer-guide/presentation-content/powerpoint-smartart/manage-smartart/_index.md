---
title: Python を使用した PowerPoint プレゼンテーションでの SmartArt の管理
linktitle: SmartArt の管理
type: docs
weight: 10
url: /ja/python-net/manage-smartart/
keywords:
- SmartArt
- SmartArt からのテキスト
- レイアウト タイプ
- 非表示プロパティ
- 組織図
- 画像組織図
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python 用 Aspose.Slides for .NET を使用して PowerPoint の SmartArt を構築および編集する方法を、スライド デザインと自動化を高速化する明確なコード サンプルとともに学びます。"
---

## **概要**

このガイドでは、Aspose.Slides for Python で SmartArt を作成および操作する方法を示します。SmartArt のテキスト抽出（ノード シェイプ内の [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) コンテンツを含む）、スライドへの SmartArt 追加とレイアウト変更、非表示ノードの検出と処理、組織図レイアウトの構成、画像組織図の作成方法を、簡潔でコピー＆ペースト可能な Python サンプルを通じて学べます。サンプルは [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を開き、スライドと SmartArt ノードを操作し、結果を PPTX として保存します。

## **SmartArt からテキストを取得する**

[SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) の `text_frame` プロパティを使用すると、ノードに含まれるテキストだけでなく、SmartArt 全体のテキストを取得できます。以下のサンプルは SmartArt ノードからテキストを取得する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("SmartArt.pptx") as presentation:
    slide = presentation.slides[0]
    smart_art = slide.shapes[0]

    for smart_art_node in smart_art.all_nodes:
        for node_shape in smart_art_node.shapes:
            if node_shape.text_frame is not None:
                print(node_shape.text_frame.text)
```

## **SmartArt のレイアウト タイプを変更する**

SmartArt のレイアウト タイプを変更するには、次の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. `BASIC_BLOCK_LIST` レイアウトで SmartArt シェイプを追加します。
1. レイアウトを `BASIC_PROCESS` に変更します。
1. プレゼンテーションを PPTX ファイルとして保存します。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # BASIC_BLOCK_LIST レイアウトで SmartArt シェイプを追加します。
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # レイアウト タイプを BASIC_PROCESS に変更します。
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # プレゼンテーションを保存します。
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt の非表示プロパティを確認する**

`SmartArtNode.is_hidden` プロパティは、データモデルでノードが非表示の場合に `True` を返します。SmartArt ノードが非表示かどうかを確認する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. `RADIAL_CYCLE` レイアウトで SmartArt シェイプを追加します。
1. SmartArt にノードを追加します。
1. `is_hidden` プロパティを確認します。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # RADIAL_CYCLE レイアウトで SmartArt シェイプを追加します。
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    # SmartArt にノードを追加します。
    node = smart.all_nodes.add_node()

    # is_hidden プロパティを確認します。
    if node.is_hidden:
        print("The node is hidden.")
```

## **組織図タイプの取得または設定**

`SmartArtNode.organization_chart_layout` プロパティは、現在のノードに関連付けられた組織図タイプを取得または設定します。組織図タイプを取得または設定する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライドに SmartArt シェイプを追加します。
1. 組織図タイプを取得または設定します。
1. プレゼンテーションを PPTX ファイルとして保存します。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # ORGANIZATION_CHART レイアウトで SmartArt シェイプを追加します。
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # 組織図の種類を設定します。
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # プレゼンテーションを保存します。
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **画像組織図の作成**

Aspose.Slides for Python は、画像組織図を簡単に作成するためのシンプルな API を提供します。スライド上にチャートを作成する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. 任意のタイプのデフォルト データでチャートを追加します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    
    presentation.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**SmartArt は RTL 言語向けのミラーリング/反転をサポートしますか？**

はい。選択された SmartArt タイプが反転をサポートしている場合、[is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) プロパティが図の向き (LTR/RTL) を切り替えます。

**同じスライドまたは別のプレゼンテーションに SmartArt をコピーして書式設定を保持するにはどうすればよいですか？**

シェイプ コレクションの [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) を使用して SmartArt シェイプを [クローン](/slides/ja/python-net/shape-manipulations/) するか、シェイプを含むスライド全体を [クローン](/slides/ja/python-net/clone-slides/) してください。どちらの方法でもサイズ、位置、スタイルが保持されます。

**SmartArt をプレビューや Web エクスポート用にラスタ画像にレンダリングするには？**

[スライドをレンダリング](/slides/ja/python-net/convert-powerpoint-to-png/)（またはプレゼンテーション全体）して PNG/JPEG に変換する API を使用します。SmartArt はスライドの一部として描画されます。

**スライドに複数の SmartArt がある場合、特定の SmartArt をプログラムで選択するには？**

一般的な方法は、[代替テキスト](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/)（Alt Text）や [名前](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/) を設定し、[Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) でその属性でシェイプを検索し、タイプが [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) であることを確認します。ドキュメントにはシェイプ検索と操作の典型的な手法が記載されています。