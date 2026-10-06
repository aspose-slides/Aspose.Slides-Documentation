---
title: Python を使用して PowerPoint プレゼンテーションの SmartArt を管理する
linktitle: SmartArt の管理
type: docs
weight: 10
url: /ja/python-net/manage-smartart/
keywords:
- スマートアート
- スマートアート テキスト
- レイアウト タイプ
- 非表示 プロパティ
- 組織図
- 画像 組織図
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "明確なコードサンプルを使用して、.NET 経由の Python 用 Aspose.Slides で PowerPoint の SmartArt を作成および編集し、スライドのデザインと自動化を迅速化する方法を学びます。"
---
## **概要**

SmartArt は、ノード、ノード シェイプ、レイアウトで構成された PowerPoint の図です。Aspose.Slides for Python via .NET を使用すると、SmartArt を作成し、ノードからテキストを読み取り、レイアウトを変更し、非表示ノードを検査し、組織図レイアウトを構成し、画像組織図を作成できます。

## **SmartArt オブジェクトからテキストを取得**

SmartArt のノードは 1 つ以上のシェイプを含むことができます。ノード シェイプからテキストを取得するには、[SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/) を反復処理し、[SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/) が返す [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) を読み取します。

この例では、少なくとも 1 枚のスライドと、そのスライド上の最初のシェイプとして SmartArt オブジェクトがあるプレゼンテーションが必要です。利用可能なすべてのテキスト フレームをコンソールに出力します。

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **SmartArt オブジェクトのレイアウト タイプを変更**

SmartArt のレイアウトはノードの配置と接続方法を制御します。次の例は、[SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` 値で SmartArt オブジェクトを作成し、`BASIC_PROCESS` 値に変更してプレゼンテーションを保存します。[ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) に渡す位置とサイズはポイント単位です。[SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) を設定してレイアウトを変更します。

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt ノードが非表示かどうかを確認**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) は、ノードが SmartArt データモデル内で非表示かどうかを示します。選択したレイアウトが可視的な図要素として表示しなくても、非表示ノードは構造内に存在する可能性があります。

次の例は、[SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` 値を使用する SmartArt オブジェクトにノードを追加し、追加されたノードの非表示状態をチェックします。ノードが非表示の場合はメッセージを出力し、図を保存します。

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **組織図レイアウトの取得または設定**

組織図レイアウトを使用する SmartArt ダイアグラムでは、[SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) が親ノードの下に子ノードがどのように配置されるかを定義します。たとえば、選択した [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) に応じて、子ノードを左側、右側、または両側にぶら下げるように設定できます。

次の例は組織図を作成し、最初のノードのレイアウトを [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING` に設定します。0 から始まるインデックス `0` が最上位ノードを選択し、その子ノードは選択された配置を使用します。変更されたプレゼンテーションを保存します。

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **画像組織図を作成**

画像組織図は、画像プレースホルダーを含む階層ダイアグラム向けに設計された SmartArt レイアウトです。スライドに SmartArt オブジェクトを追加する際に、[SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` 値を使用します。この例は画像プレースホルダーを含むダイアグラムを保存しますが、プレースホルダーに画像は設定しません。

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **レガシー ダイアグラムをシェイプ グループに変換**

既存のプレゼンテーションを最新化する際、PowerPoint 97–2003 で作成された組織図を更新する必要がある場合があります。Aspose.Slides はこれらのレガシー ダイアグラムを [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) オブジェクトとして表します。[LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) を使用して、ダイアグラムをシェイプ グループに変換し、個々のビジュアル要素を編集できるようにします。詳細は [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) を参照してください。

変換は元のダイアグラムを削除せずにシェイプ コレクションに新しいグループを追加します。変換が成功したら、[ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) で元のダイアグラムを削除し、重複コンテンツを回避します。シェイプの追加と削除が反復処理を妨げないよう、変換前にレガシー ダイアグラムをリストに収集します。

次の例はプレゼンテーションを開き、すべてのスライドを検索し、ダイアグラムをシェイプ グループに変換して、更新されたプレゼンテーションを PPTX として保存します。

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

保存されたプレゼンテーションには、変換されたレガシー ダイアグラムの代わりに編集可能なシェイプ グループが含まれ、元のダイアグラムは残っていません。PowerPoint で PPTX を開き、各グループ内のテキスト、塗りつぶし、位置などの個々の要素を編集できます。

## **よくある質問**

**SmartArt は RTL 言語向けにミラーリングや反転をサポートしていますか？**

はい。[SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) プロパティは、選択した SmartArt レイアウトが反転をサポートしている場合に、左から右への方向を右から左へ、またはその逆に切り替えます。

**同じスライドまたは別のプレゼンテーションに SmartArt をコピーして書式を保持するにはどうすればよいですか？**

[SmartArt シェイプをクローン](/slides/ja/python-net/shape-manipulations/) には [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) を、SmartArt を含むスライド全体をコピーするには [スライド全体をクローン](/slides/ja/python-net/clone-slides/) を使用できます。どちらの方法もサイズ、位置、書式を保持します。

**SmartArt をプレビューや Web エクスポート用のラスター画像にレンダリングするにはどうすればよいですか？**

[スライドをレンダー](/slides/ja/python-net/convert-powerpoint-to-png/) するか、プレゼンテーション全体を PNG または JPEG に変換します。SmartArt はスライドの一部としてレンダリングされます。

**複数の SmartArt オブジェクトがある場合、特定のオブジェクトをスライド上で見つけるにはどうすればよいですか？**

SmartArt シェイプに固有の [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) または [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) の値を設定し、[Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) でその値を検索し、マッチしたシェイプが [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/) であることを確認します。