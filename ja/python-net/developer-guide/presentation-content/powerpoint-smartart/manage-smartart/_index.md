---
title: Python を使用した PowerPoint プレゼンテーションでの SmartArt の管理
linktitle: SmartArt の管理
type: docs
weight: 10
url: /ja/python-net/manage-smartart/
keywords:
- SmartArt
- SmartArt のテキスト
- レイアウト タイプ
- 非表示プロパティ
- 組織図
- 画像組織図
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "明確なコードサンプルを使用して、Python 用 Aspose.Slides for .NET で PowerPoint の SmartArt を作成および編集し、スライドのデザインと自動化を高速化する方法を学びます。"
---

## **概要**

このガイドでは、Aspose.Slides for Python で SmartArt を作成および操作する方法をご紹介します。SmartArt からテキストを抽出する方法（ノード シェイプ内の [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) コンテンツを含む）、スライドに SmartArt を追加してレイアウトを切り替える方法、非表示ノードの検出と処理、組織図レイアウトの設定、画像組織図の作成方法を学べます。すべて、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を開き、スライドと SmartArt ノードを操作し、結果を PPTX に保存する簡潔なコピー＆ペースト可能な Python のサンプルで示しています。

## **SmartArt からテキストを取得**

`text_frame` プロパティは [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) にあり、SmartArt シェイプ全体のテキストを取得できます（ノードに含まれるテキストだけではありません）。以下のサンプルコードは SmartArt ノードからテキストを取得する方法を示しています。
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


## **SmartArt のレイアウト タイプを変更**

SmartArt のレイアウト タイプを変更するには、次の手順に従います：

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

    # レイアウトタイプを BASIC_PROCESS に変更します。
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # プレゼンテーションを保存します。
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```


## **SmartArt の非表示プロパティを確認**

`SmartArtNode.is_hidden` プロパティは、データモデルでノードが非表示の場合に `True` を返します。SmartArt ノードが非表示かどうかを確認するには、次の手順に従います：

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

`SmartArtNode.organization_chart_layout` プロパティは、現在のノードに関連付けられた組織図タイプを取得または設定します。組織図タイプを取得または設定するには、次の手順に従います：

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

    # 組織図のタイプを設定します。
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # プレゼンテーションを保存します。
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```


## **画像組織図の作成**

Aspose.Slides for Python は、画像組織図を簡単に作成できるシンプルな API を提供します。スライドにチャートを作成するには：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. 必要なタイプのデフォルト データでチャートを追加します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    
    presentation.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**SmartArt は RTL 言語向けのミラーリング/反転をサポートしていますか？**

はい。選択した SmartArt タイプが反転に対応している場合、[is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) プロパティで図の方向（LTR/RTL）を切り替えることができます。

**SmartArt を同じスライドまたは別のプレゼンテーションにコピーし、書式を保持するにはどうすればよいですか？**

[clone the SmartArt shape](/slides/ja/python-net/shape-manipulations/) をシェイプ コレクション（[ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)）経由で、またはこのシェイプを含むスライド全体を[clone the entire slide](/slides/ja/python-net/clone-slides/) でクローンできます。どちらの方法もサイズ、位置、スタイリングを保持します。

**SmartArt をプレビューやウェブエクスポート用のラスター画像としてレンダリングするには？**

[Render the slide](/slides/ja/python-net/convert-powerpoint-to-png/)（またはプレゼンテーション全体）を PNG/JPEG に変換する API を使用してスライドやプレゼンテーションを画像に変換します。SmartArt はスライドの一部として描画されます。

**スライドに複数の SmartArt がある場合、特定の SmartArt をプログラムで選択するにはどうすればよいですか？**

一般的な方法は、[alternative text](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/)（Alt Text）または[name](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/) を使用し、[Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) 内でその属性でシェイプを検索し、タイプが [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) であることを確認します。ドキュメントにはシェイプの検索と操作に関する典型的な手法が記載されています。