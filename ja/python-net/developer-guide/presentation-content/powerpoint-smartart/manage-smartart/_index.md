---
title: PowerPoint プレゼンテーションで Python を使用して SmartArt を管理する
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint SmartArt の作成と編集を学び、スライドのデザインと自動化を高速化する明確なコードサンプルをご紹介します。"
---

## **概要**

このガイドでは、Aspose.Slides for Python を使用して SmartArt の作成と操作方法を示します。SmartArt のノード形状内の [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) コンテンツを含むテキストの抽出、スライドへの SmartArt の追加とレイアウトの切替、非表示ノードの検出と処理、組織図レイアウトの構成、画像組織図の作成方法を、簡潔でコピー＆ペースト可能な Python の例を通じて学べます。例では [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を開き、スライドと SmartArt ノードを操作し、結果を PPTX として保存します。

## **SmartArt からテキストを取得**

`text_frame` プロパティは、SmartArt シェイプ全体のテキストを取得でき、ノード内のテキストだけでなくすべてのテキストが取得できます。以下のサンプルコードは、SmartArt ノードからテキストを取得する方法を示しています。

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
2. インデックスでスライドへの参照を取得します。  
3. `BASIC_BLOCK_LIST` レイアウトで SmartArt シェイプを追加します。  
4. レイアウトを `BASIC_PROCESS` に変更します。  
5. プレゼンテーションを PPTX ファイルとして保存します。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the BASIC_BLOCK_LIST layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # Change the layout type to BASIC_PROCESS.
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # Save the presentation.
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt の非表示プロパティを確認する**

`SmartArtNode.is_hidden` プロパティは、データモデルでノードが非表示の場合に `True` を返します。SmartArt ノードが非表示かどうかを確認するには、次の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. `RADIAL_CYCLE` レイアウトで SmartArt シェイプを追加します。  
3. SmartArt にノードを追加します。  
4. `is_hidden` プロパティを確認します。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the RADIAL_CYCLE layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    # Add a node to the SmartArt.
    node = smart.all_nodes.add_node()

    # Check the is_hidden property.
    if node.is_hidden:
        print("The node is hidden.")
```

## **組織図タイプの取得または設定**

`SmartArtNode.organization_chart_layout` プロパティは、現在のノードに関連付けられた組織図タイプを取得または設定します。組織図タイプを取得または設定するには、次の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. スライドに SmartArt シェイプを追加します。  
3. 組織図タイプを取得または設定します。  
4. プレゼンテーションを PPTX ファイルとして保存します。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the ORGANIZATION_CHART layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # Set the organization chart type.
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # Save the presentation.
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **画像組織図の作成**

Aspose.Slides for Python は、画像組織図を簡単に作成できるシンプルな API を提供します。スライド上にチャートを作成する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. 希望のタイプのデフォルトデータでチャートを追加します。  
4. 変更したプレゼンテーションを PPTX ファイルとして保存します。

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

はい。選択した SmartArt タイプが反転に対応している場合、[is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) プロパティでダイアグラムの方向 (LTR/RTL) を切り替えることができます。

**書式を保持したまま、同じスライドまたは別のプレゼンテーションに SmartArt をコピーするにはどうすればよいですか？**

シェイプ コレクションの [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) を使用して SmartArt シェイプを [clone the SmartArt shape](/slides/ja/python-net/shape-manipulations/) するか、当該シェイプが含まれるスライド全体を [clone the entire slide](/slides/ja/python-net/clone-slides/) してください。どちらの方法でもサイズ、位置、スタイリングが保持されます。

**プレビューや Web エクスポートのために SmartArt をラスタ画像にレンダリングするにはどうすればよいですか？**

スライド（またはプレゼンテーション全体）を PNG/JPEG に変換する API を使用して [Render the slide](/slides/ja/python-net/convert-powerpoint-to-png/) してください。SmartArt はスライドの一部として描画されます。

**複数の SmartArt がある場合、スライド上で特定の SmartArt をプログラムで選択する方法はありますか？**

一般的な方法は、[alternative text](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/)（Alt Text）や [name](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/) を設定し、[Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) でその属性でシェイプを検索し、タイプが [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) であることを確認します。ドキュメントにはシェイプ検索と操作の典型的な手法が記載されています。