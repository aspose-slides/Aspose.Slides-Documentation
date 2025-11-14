---
title: Python を使用して PowerPoint プレゼンテーションの SmartArt を管理する
linktitle: SmartArt の管理
type: docs
weight: 10
url: /ja/python-net/manage-smartart/
keywords:
- SmartArt
- SmartArt のテキスト
- レイアウトの種類
- 非表示プロパティ
- 組織図
- 画像入り組織図
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "明確なコードサンプルを使用して、Aspose.Slides for Python via .NET で PowerPoint SmartArt を構築および編集する方法を学び、スライドの設計と自動化を高速化します。"
---

## **SmartArtからテキストを取得する**
ISmartArtShapeインターフェイスおよびSmartArtShapeクラスにTextFrameプロパティが追加されました。このプロパティを使用すると、ノードテキストだけでなくSmartArtからすべてのテキストを取得できます。以下のサンプルコードは、SmartArtノードからテキストを取得するのに役立ちます。

```py
import aspose.slides as slides

with slides.Presentation(path + "SmartArt.pptx") as pres:
    slide = pres.slides[0]
    smartArt = slide.shapes[0]

    for smartArtNode in smartArt.all_nodes:
        for nodeShape in smartArtNode.shapes:
            if nodeShape.text_frame != None:
                print(nodeShape.text_frame.text)
```



## **SmartArtのレイアウトタイプを変更する**
SmartArtのレイアウトタイプを変更するために、以下の手順に従ってください。

- `Presentation`クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- SmartArt BasicBlockListを追加します。
- LayoutTypeをBasicProcessに変更します。
- プレゼンテーションをPPTXファイルとして保存します。
  以下の例では、2つのシェイプの間にコネクタを追加しています。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # SmartArt BasicProcessを追加する 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # LayoutTypeをBasicProcessに変更する
    smart.layout = art.SmartArtLayoutType.BASIC_PROCESS
    # プレゼンテーションを保存
    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```



## **SmartArtの隠しプロパティを確認する**
メソッドcom.aspose.slides.ISmartArtNode.isHidden()は、このノードがデータモデル内の隠しノードである場合にtrueを返すことに注意してください。SmartArtの任意のノードの隠しプロパティを確認する手順は、以下の通りです。

- `Presentation`クラスのインスタンスを作成します。
- SmartArt RadialCycleを追加します。
- SmartArtにノードを追加します。
- isHiddenプロパティを確認します。
- プレゼンテーションをPPTXファイルとして保存します。

以下の例では、2つのシェイプの間にコネクタを追加しています。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # SmartArt BasicProcessを追加する 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.RADIAL_CYCLE)
    # SmartArtにノードを追加する 
    node = smart.all_nodes.add_node()
    # isHiddenプロパティを確認する
    if node.is_hidden:
        print("hidden")
        # 処理や通知を行う
    # プレゼンテーションを保存
    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```



## **組織図タイプを取得または設定する**
メソッドcom.aspose.slides.ISmartArtNode.getOrganizationChartLayout()およびsetOrganizationChartLayout(int)は、現在のノードに関連付けられた組織図タイプの取得または設定を行います。組織図タイプを取得または設定するための手順は、以下の通りです。

- `Presentation`クラスのインスタンスを作成します。
- スライドにSmartArtを追加します。
- 組織図タイプを取得または設定します。
- プレゼンテーションをPPTXファイルとして保存します。
  以下の例では、2つのシェイプの間にコネクタを追加しています。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # SmartArt BasicProcessを追加する 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.ORGANIZATION_CHART)
    # 組織図タイプを取得または設定する 
    smart.nodes[0].organization_chart_layout = art.OrganizationChartLayoutType.LEFT_HANGING
    # プレゼンテーションを保存
    presentation.save("OrganizeChartLayoutType_out.pptx", slides.export.SaveFormat.PPTX)
```




## **画像組織図を作成する**
Aspose.Slides for Python via .NETは、簡単に画像組織図を作成できるシンプルなAPIを提供します。スライドにチャートを作成するには：

1. `Presentation`クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. 希望するタイプ（ChartType.PictureOrganizationChart）でデフォルトデータを持つチャートを追加します。
1. 変更されたプレゼンテーションをPPTXファイルとして保存します。

以下のコードは、チャートを作成するために使用されます。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as pres:
    smartArt = pres.slides[0].shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    pres.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```