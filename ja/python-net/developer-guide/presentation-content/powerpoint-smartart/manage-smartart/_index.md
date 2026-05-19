---
title: Python で PowerPoint プレゼンテーションの SmartArt を管理
linktitle: SmartArt を管理
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
description: ".NET 経由で Python 用 Aspose.Slides を使用して、PowerPoint の SmartArt を作成・編集する方法を、スライド設計と自動化を高速化する明確なコードサンプルとともに学びます。"
---
## **概要**

SmartArt はノード、ノードシェイプ、およびレイアウトで構成される PowerPoint の図です。Aspose.Slides for Python via .NET を使用すると、SmartArt の作成、ノードからのテキストの読み取り、レイアウトの変更、非表示ノードの検査、組織図レイアウトの設定、画像組織図の作成ができます。

## **SmartArt オブジェクトからテキストを取得**

SmartArt ノードは1つ以上のシェイプを含むことができます。表示されているテキストを取得するには、[SmartArt.all_nodes](https://reference.aspose.com/slides/ja/python-net/aspose.slides.smartart/smartart/all_nodes/) を反復処理し、次に [SmartArtShape.text_frame](https://reference.aspose.com/slides/ja/python-net/aspose.slides.smartart/smartartshape/text_frame/) が返す [TextFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/) を読み取ります。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **SmartArt オブジェクトのレイアウトタイプを変更**

SmartArt のレイアウトはノードの配置と接続方法を制御します。以下の例は、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.smartart/smartartlayouttype/) の `BASIC_BLOCK_LIST` 値で SmartArt オブジェクトを作成し、`BASIC_PROCESS` 値に変更してプレゼンテーションを保存します。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt ノードが非表示かどうかを確認**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/ja/python-net/aspose.slides.smartart/smartartnode/is_hidden/) は、SmartArt データモデルでノードが非表示かどうかを示します。選択したレイアウトで表示されない場合でも、非表示ノードは構造内に存在する可能性があります。

以下の例は、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.smartart/smartartlayouttype/) の `RADIAL_CYCLE` 値を使用する SmartArt オブジェクトにノードを追加し、そのノードの非表示状態を確認します。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **組織図レイアウトの取得または設定**

組織図レイアウトを使用する SmartArt 図の場合、[SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/ja/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) は親ノード下の子ノードの配置方法を定義します。たとえば、選択した [OrganizationChartLayoutType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.smartart/organizationchartlayouttype/) に応じて、子ノードを左側、右側、または両側にぶら下げるように設定できます。

以下の例は組織図を作成し、最初のノードのレイアウトを [OrganizationChartLayoutType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.smartart/organizationchartlayouttype/) の `LEFT_HANGING` 値に設定します。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **画像組織図を作成**

画像組織図は、画像プレースホルダーを含む階層図向けに設計された SmartArt のレイアウトです。スライドに SmartArt オブジェクトを追加する際は、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.smartart/smartartlayouttype/) の `PICTURE_ORGANIZATION_CHART` 値を使用してください。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**SmartArt は RTL 言語向けにミラーリングや反転をサポートしますか？**

はい。選択した SmartArt レイアウトが反転をサポートしている場合、[SmartArt.is_reversed](https://reference.aspose.com/slides/ja/python-net/aspose.slides.smartart/smartart/is_reversed/) プロパティにより、図の方向を左から右 (LTR) から右から左 (RTL) に、またはその逆に切り替えることができます。

**SmartArt を同じスライドまたは別のプレゼンテーションにコピーして、書式設定を保持するにはどうすればよいですか？**

SmartArt が含まれるスライドを対象に、[ShapeCollection.add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_clone/) を使用して [SmartArt シェイプをクローン](/slides/ja/python-net/shape-manipulations/) するか、[スライド全体をクローン](/slides/ja/python-net/clone-slides/) できます。どちらの方法でもサイズ、位置、書式設定が保持されます。

**プレビューや Web エクスポート用に SmartArt をラスタ画像としてレンダリングするにはどうすればよいですか？**

スライド全体またはプレゼンテーション全体を PNG または JPEG に変換して [スライドをレンダリング](/slides/ja/python-net/convert-powerpoint-to-png/) します。SmartArt はスライドの一部としてレンダリングされます。

**スライドに SmartArt が複数ある場合、特定の SmartArt オブジェクトを見つけるにはどうすればよいですか？**

SmartArt シェイプに固有の [Shape.alternative_text](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/alternative_text/) または [Shape.name](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/name/) の値を設定し、[Slide.shapes](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/shapes/) でその値を検索し、該当するシェイプが [SmartArt](https://reference.aspose.com/slides/ja/python-net/aspose.slides.smartart/smartart/) であることを確認します。